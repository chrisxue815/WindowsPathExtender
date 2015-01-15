using System;

namespace WindowsPathExtender.Loader.Exceptions
{
    public class EnvNotFoundException : Exception
    {
        public EnvNotFoundException(string envName)
            : base(GenerateMessage(envName))
        {
        }

        public static string GenerateMessage(string envName)
        {
            //TODO
            return null;
        }
    }
}
