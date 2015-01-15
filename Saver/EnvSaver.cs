using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace WindowsPathExtender.Saver
{
    public class EnvSaver
    {
        public const int MaxLength = 2047;

        public string EnvName { get; set; }
        public string EnvFormat { get; set; }
        public EnvironmentVariableTarget EnvLocation { get; set; }
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }
        public bool BackupBeforeSaving { get; set; }
        public bool Check { get; set; }

        private string backupPath;

        public EnvSaver()
        {
            var backupName = DateTime.Now.ToString("yyyyMMdd_HHmmss_zz");
            backupPath = string.Format("backup/{0}.txt", backupName);
        }

        public void Save()
        {
            WriteRegHeader(backupPath);
            WriteRegHeader(OutputFilePath);

            var pathBuilder = new StringBuilder(MaxLength);
            var extBuilder = new StringBuilder(MaxLength);
            var extBuilders = new List<StringBuilder> { extBuilder };

            using (var file = new StreamReader(InputFilePath))
            {
                string path;
                while ((path = file.ReadLine()) != null)
                {
                    const string mark = "# ";
                    if (path.StartsWith(mark))
                    {
                        if (Check) continue;
                        path = path.Substring(mark.Length);
                    }

                    if (extBuilder.Length + path.Length < MaxLength)
                    {
                        if (extBuilder.Length > 0) extBuilder.Append(';');
                        extBuilder.Append(path);
                    }
                    else
                    {
                        extBuilder = new StringBuilder(MaxLength);
                        extBuilder.Append(path);
                        extBuilders.Add(extBuilder);
                    }
                }
            }

            if (extBuilders.Count == 1)
            {
                BackupAndSave(EnvName, extBuilder.ToString(), RegistryValueKind.ExpandString);
            }
            else
            {
                for (var i = 0; i < extBuilders.Count; i++)
                {
                    var envName = string.Format(EnvFormat, i);

                    var envVar = string.Format("%{0}%", envName);
                    if (pathBuilder.Length > 0) pathBuilder.Append(';');
                    pathBuilder.Append(envVar);

                    extBuilder = extBuilders[i];
                    BackupAndSave(envName, extBuilder.ToString());
                }

                BackupAndSave(EnvName, pathBuilder.ToString(), RegistryValueKind.ExpandString);
            }

            Console.WriteLine("Successfully saved to {0}", OutputFilePath);
            Console.WriteLine("Backup saved to {0}", backupPath);
            Console.WriteLine();

            RunReg();
        }

        private void RunReg()
        {
            var windir = Environment.GetEnvironmentVariable("WINDIR");
            var regExeName = windir + "\\regedit.exe";
            var regArgs = "/S " + OutputFilePath;

            Console.WriteLine("> {0} {1}", regExeName, regArgs);

            var startInfo = new ProcessStartInfo
            {
                FileName = regExeName,
                Arguments = regArgs,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            var process = Process.Start(startInfo);
            process.WaitForExit();

            if (process.ExitCode == 0) Console.WriteLine("Succeed");

            NotifyProcesses();
        }

        private void BackupAndSave(string envName, string envValue, RegistryValueKind kind = RegistryValueKind.String)
        {
            if (BackupBeforeSaving) Backup(envName);
            WriteRegValue(OutputFilePath, envName, envValue, kind);
        }

        private void Backup(string envName)
        {
            var envValue = Environment.GetEnvironmentVariable(envName, EnvLocation);
            if (envValue == null) return;

            var reg = OpenRegistryKey();
            var kind = reg.GetValueKind(envName);
            WriteRegValue(backupPath, envName, envValue, kind);
        }

        private void WriteRegValue(string path, string envName, string envValue, RegistryValueKind kind = RegistryValueKind.String)
        {
            using (var file = new StreamWriter(path, true))
            {
                file.Write("\"{0}\"=", envName);

                switch (kind)
                {
                    case RegistryValueKind.String:
                        envValue = envValue.Replace("\\", "\\\\");
                        envValue = envValue.Replace("\"", "\\\"");
                        file.WriteLine("\"{0}\"", envValue);
                        break;
                    case RegistryValueKind.ExpandString:
                        file.Write("hex(2):");
                        WriteExpandString(file, envValue);
                        break;
                }

                file.WriteLine();
            }
        }

        private void WriteExpandString(TextWriter writer, string envValue)
        {
            foreach (var ch in envValue)
            {
                var low = (byte) ch;
                var high = (byte) ch >> 8;

                writer.Write("{0:X2},{1:X2},", low, high);
            }

            writer.WriteLine("00,00");
        }

        private void WriteRegHeader(string path)
        {
            using (var file = new StreamWriter(path))
            {
                file.WriteLine("Windows Registry Editor Version 5.00");
                file.WriteLine();

                var keyPath = EnvLocation == EnvironmentVariableTarget.Machine
                    ? @"[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment]"
                    : @"[HKEY_CURRENT_USER\Environment]";

                file.WriteLine(keyPath);
                file.WriteLine();
            }
        }

        private RegistryKey OpenRegistryKey()
        {
            return EnvLocation == EnvironmentVariableTarget.Machine
                ? Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Environment")
                : Registry.CurrentUser.OpenSubKey("Environment");
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, string lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult);

        private static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        private const int WM_SETTINGCHANGE = 0x1a;
        private const int SMTO_ABORTIFHUNG = 0x0002;

        private static void NotifyProcesses()
        {
            SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, IntPtr.Zero, "Environment", SMTO_ABORTIFHUNG, 100, IntPtr.Zero);
        }
    }
}
