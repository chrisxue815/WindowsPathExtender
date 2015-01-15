using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsPathExtender.Loader.Exceptions
{
    public class InfiniteRecursionException : Exception
    {
        public InfiniteRecursionException(string current, Stack<string> loadingStack)
            : base(GenerateMessage(current, loadingStack))
        {
        }

        public static string GenerateMessage(string current, Stack<string> loadingStack)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Infinite recursion detected. Env referencing stack:");
            builder.AppendLine(current);

            while (loadingStack.Count > 0)
            {
                var loadingEnv = loadingStack.Pop();
                builder.AppendLine(loadingEnv);
            }

            return builder.ToString();
        }
    }
}
