using System;
using NDesk.Options;

namespace WindowsPathExtender.Saver
{
    public class Cmd
    {
        public Cmd()
        {
        }

        public void Run(string[] args)
        {
            var exeName = AppDomain.CurrentDomain.FriendlyName;
            var envName = "Path";
            var envFormat = "Path_{0}";
            var envLocation = "sys";
            var inputFilePath = "tmp/env.txt";
            var outputFilePath = "tmp/save.reg";
            var backupBeforeSaving = true;
            var check = true;
            var showHelp = false;

            var p = new OptionSet
            {
                { "n|name=",
                   string.Format("The name of the environment variable to be saved. Default value \"{0}\".", envName),
                   v => envName = v},
                { "f|format=",
                   string.Format("The name format of the extra environment variables. Default value \"{0}\".", envFormat),
                   v => envFormat = v },
                { "l|location=",
                   string.Format("The location where the environment variable will be saved. Either \"sys\" or \"user\". Default value: \"{0}\"", envLocation),
                   v => envLocation = v },
                { "i|in=",
                   string.Format("The input file path. Default value: \"{0}\".", inputFilePath),
                   v => inputFilePath = v },
                { "o|out=",
                   string.Format("The output file path. Default value: \"{0}\".", outputFilePath),
                   v => outputFilePath = v },
                { "b|backup",
                   "Backup before saving. Enabled by default. Use -b- or --backup- to disable.",
                   v => backupBeforeSaving = v != null },
                { "c|check",
                   "Check and remove non-existent paths. Enabled by default. Use -c- or --check- to disable.",
                   v => check = v != null },
                { "?|h|help", 
                   "Show this message and exit.",
                   v => showHelp = v != null },
            };

            try
            {
                p.Parse(args);

                if (showHelp)
                {
                    ShowHelp(p);
                    return;
                }

                var saver = new EnvSaver
                {
                    EnvName = envName,
                    EnvFormat = envFormat,
                    EnvLocation = ParseLocation(envLocation),
                    InputFilePath = inputFilePath,
                    OutputFilePath = outputFilePath,
                    BackupBeforeSaving = backupBeforeSaving,
                    Check = check
                };

                saver.Save();
            }
            catch (OptionException e)
            {
                Console.Write("{0}: ", exeName);
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `{0} --help' for more information.", exeName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ShowHelp(OptionSet p)
        {
            var exeName = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine("Usage: {0} [Options]", exeName);
            Console.WriteLine();
            Console.WriteLine("Description:");
            Console.WriteLine("    Generate a batch file to set the environment variables.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        public EnvironmentVariableTarget ParseLocation(string target)
        {
            switch (target)
            {
                case "sys":
                    return EnvironmentVariableTarget.Machine;
                case "user":
                    return EnvironmentVariableTarget.User;
                default:
                    throw new Exception(string.Format("Target must be either \"sys\" or \"user\". Current value: {0}", target));
            }
        }
    }
}
