using System.IO;

namespace WindowsPathExtender.Loader
{
    public class Utils
    {
        public static void CreateParentDirs(string path)
        {
            var file = new FileInfo(path);
            file.Directory.Create();
        }
    }
}
