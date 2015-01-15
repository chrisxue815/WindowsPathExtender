using System;
using NDesk.Options;

namespace WindowsPathExtender.Loader
{
    public class Cmd
    {
        public void Run(string[] args)
        {
            var exeName = AppDomain.CurrentDomain.FriendlyName;
            var envName = "Path";
            var envLocations = "both";
            var sort = true;
            var check = true;
            var expand = true;
            var showHelp = false;
            var outputFilePath = "tmp/env.txt";

            var p = new OptionSet
            {
                { "n|name=",
                   string.Format("The name of the environment variable to be loaded. Default value: \"{0}\".", envName),
                   v => envName = v },
                { "l|location=",
                   string.Format("The location where the environment variable will be loaded. Either \"sys\", \"user\", or \"both\". Default value: \"{0}\"", envLocations),
                   v => envLocations = v },
                { "o|out=",
                    string.Format("The output file path. Default value: \"{0}\".", outputFilePath),
                   v => outputFilePath = v },
                { "s|sort",
                   "Sort paths alphabetically (not recommended). Disabled by default.",
                   v => sort = v != null },
                { "c|check",
                   "Check the existence of paths. Enabled by default. Use -c or --check- to disable.",
                   v => check = v != null },
                { "e|expand",
                   "Expand inner environment variables. Enabled by default. Use -e or --expand- to disable.",
                   v => expand = v != null },
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

                var loader = new EnvLoader
                {
                    EnvName = envName,
                    EnvLocations = ParseLocations(envLocations),
                    OutputFilePath = outputFilePath,
                    Sort = sort,
                    Check = check,
                    Expand = expand
                };

                loader.Load();
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
            Console.WriteLine("    Load the environment variables to the output file.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        public EnvironmentVariableTarget[] ParseLocations(string targets)
        {
            switch (targets)
            {
                case "both":
                    return new[] { EnvironmentVariableTarget.Machine, EnvironmentVariableTarget.User };
                case "sys":
                    return new[] { EnvironmentVariableTarget.Machine };
                case "user":
                    return new[] { EnvironmentVariableTarget.User };
                default:
                    throw new Exception(string.Format("Target must be either \"sys\", \"user\", or \"both\". Current value: {0}", targets));
            }
        }
    }
}
