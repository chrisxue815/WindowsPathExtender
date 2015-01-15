using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsPathExtender.Properties;

namespace WindowsPathExtender
{
    public partial class Form1 : Form
    {
        public const string LoaderExeName = "extender-loader.exe";
        public const string SaverExeName = "extender-saver.exe";

        public Form1()
        {
            InitializeComponent();

            statusLabel1.Text = "";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            toolStrip1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            statusLabel1.Text = "Loading...";

            var loaderArgs = GenerateLoaderArguments();
            textBoxLog.AppendText(string.Format("> {0} {1}\n", LoaderExeName, loaderArgs));

            var startInfo = new ProcessStartInfo
            {
                FileName = LoaderExeName,
                Arguments = loaderArgs,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            var process = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            process.Exited += (o, args) => Invoke((MethodInvoker)delegate
            {
                toolStrip1.Enabled = true;
                progressBar1.Style = ProgressBarStyle.Continuous;
                statusLabel1.Text = "";

                var log = process.StandardOutput.ReadToEnd();
                textBoxLog.AppendText(log);
                textBoxLog.AppendText("\n");

                if (process.ExitCode == 0)
                {
                    var env = File.ReadAllText(Settings.Default.LoadOutput);
                    textBoxEnv.Text = env;
                    groupBoxEnv.Text = Settings.Default.LoadOutput;
                }
            });

            process.Start();
        }

        private static string GenerateLoaderArguments()
        {
            var builder = new StringBuilder();
            var settings = Settings.Default;

            builder.AppendFormat("-n={0} -l={1} -o={2} -s{3} -c{4} -e{5}",
                settings.LoadName, settings.LoadLocation, settings.LoadOutput, GetSign(settings.LoadSort), GetSign(settings.LoadCheck), GetSign(settings.LoadExpand));

            return builder.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            toolStrip1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            statusLabel1.Text = "Saving...";

            File.WriteAllText(Settings.Default.LoadOutput, textBoxEnv.Text);
            groupBoxEnv.Text = Settings.Default.LoadOutput;

            var saverArgs = GenerateSaverArguments();
            textBoxLog.AppendText(string.Format("> {0} {1}\n", SaverExeName, saverArgs));

            var startInfo = new ProcessStartInfo
            {
                FileName = SaverExeName,
                Arguments = saverArgs,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };

            var process = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            process.Exited += (o, args) => Invoke((MethodInvoker)delegate
            {
                toolStrip1.Enabled = true;
                progressBar1.Style = ProgressBarStyle.Continuous;
                statusLabel1.Text = "";

                var log = process.StandardOutput.ReadToEnd();
                textBoxLog.AppendText(log);
                textBoxLog.AppendText("\n");
            });

            process.Start();
        }

        private static string GenerateSaverArguments()
        {
            var builder = new StringBuilder();
            var settings = Settings.Default;

            builder.AppendFormat("-n={0} -f={1} -l={2} -i={3} -o={4} -b{5} -c{6}",
                settings.SaveName, settings.SaveFormat, settings.SaveLocation, settings.SaveInput, settings.SaveOutput, GetSign(settings.SaveBackup), GetSign(settings.SaveCheck));

            return builder.ToString();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog(this);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }

        private static char GetSign(bool v)
        {
            return v ? '+' : '-';
        }

        private void textBoxEnv_TextChanged(object sender, EventArgs e)
        {
            if (!groupBoxEnv.Text.StartsWith("* ")) groupBoxEnv.Text = "* " + groupBoxEnv.Text;
        }
    }
}
