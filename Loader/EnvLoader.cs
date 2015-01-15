using System;
using System.Collections.Generic;
using System.IO;
using WindowsPathExtender.Loader.Exceptions;

namespace WindowsPathExtender.Loader
{
    public class EnvLoader
    {
        public string EnvName { get; set; }
        public EnvironmentVariableTarget[] EnvLocations { get; set; }
        public string OutputFilePath { get; set; }
        public bool Sort { get; set; }
        public bool Check { get; set; }
        public bool Expand { get; set; }

        private readonly Dictionary<string, Env> envDict;
        private readonly Stack<string> loadingStack;

        public EnvLoader()
        {
            envDict = new Dictionary<string, Env>();
            loadingStack = new Stack<string>();
        }

        public void Load()
        {
            var env = LoadEnv(EnvName);

            if (Sort) env.Sort();

            if (Check) CheckNonExistentPaths(env);

            Utils.CreateParentDirs(OutputFilePath);
            File.WriteAllText(OutputFilePath, env.ToString());

            Console.WriteLine("Successfully loaded to {0}", OutputFilePath);
        }

        private Env LoadEnv(string envName)
        {
            if (loadingStack.Contains(envName))
            {
                throw new InfiniteRecursionException(envName, loadingStack);
            }

            loadingStack.Push(envName);

            Env env;
            envDict.TryGetValue(envName, out env);

            if (env == null)
            {
                var envValue = GetEnvValue(envName);
                if (envValue == null) throw new EnvNotFoundException(envName);

                env = ParseEnv(envValue);

                envDict.Add(envName, env);
            }

            loadingStack.Pop();

            return env;
        }

        /// <summary>
        /// Expands environment-variable strings and replaces them with the values recursively.
        /// Converts semi-colon to line-break.
        /// Trims leading/trailing whitespace.
        /// Trims trailing slash.
        /// </summary>
        /// <param name="envValue"></param>
        /// <returns></returns>
        private Env ParseEnv(string envValue)
        {
            var env = new Env();
            var paths = envValue.Split(';');

            foreach (var rawPath in paths)
            {
                var path = rawPath.Trim();
                path = path.TrimEnd('\\');

                var newEnv = Expand ? ExpandEnv(path) : new Env { path };

                env.AddRange(newEnv);
            }

            return env;
        }

        private Env ExpandEnv(string envName)
        {
            var env = new Env();
            var capturingInnerEnv = false;
            var envLeft = 0;

            for (var i = 0; i < envName.Length; i++)
            {
                var c = envName[i];

                if (c == '%')
                {
                    if (!capturingInnerEnv)
                    {
                        envLeft = i;
                    }
                    else
                    {
                        var innerEnvName = envName.Substring(envLeft + 1, i - envLeft - 1);
                        Env innerEnv;

                        try
                        {
                            innerEnv = LoadEnv(innerEnvName);
                        }
                        catch (EnvNotFoundException)
                        {
                            Console.WriteLine("Warning: env \"{0}\" cannot be found. Referenced by env \"{1}\".", innerEnvName, envName);
                            innerEnv = new Env { string.Format("%{0}%", innerEnvName) };
                        }

                        var intersection = env.LastOrDefault + innerEnv.FirstOrDefault;
                        if (intersection != "") env.LastOrDefault = intersection;
                        env.AddRange(innerEnv, 1);
                    }

                    capturingInnerEnv = !capturingInnerEnv;
                }
                else
                {
                    if (!capturingInnerEnv)
                    {
                        env.LastOrDefault += c;
                    }
                }
            }

            if (capturingInnerEnv)
            {
                var remaining = envName.Substring(envLeft);
                env.LastOrDefault += remaining;
            }

            return env;
        }

        private string GetEnvValue(string envName)
        {
            string envValue = null;

            foreach (var envTarget in EnvLocations)
            {
                var v = Environment.GetEnvironmentVariable(envName, envTarget);
                if (v != null)
                {
                    if (envValue == null) envValue = v;
                    else envValue += ";" + v;
                }
            }

            return envValue;
        }

        private void CheckNonExistentPaths(Env env)
        {
            for (var i = 0; i < env.Count; i++)
            {
                if (!env[i].Contains("%") && !Directory.Exists(env[i]))
                {
                    env[i] = "# " + env[i];
                }
            }
        }
    }
}
