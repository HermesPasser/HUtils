using System;

using System.IO;

namespace HUtils
{
    public static class DirUtils
    {
        public static readonly int MaxPathLength = 259;
        public static readonly string[] InvalidPathNames = { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
        
        public static bool IsValidAsDir(string path)
        {
            string drive = Directory.GetDirectoryRoot(path);
            if (!Directory.Exists(drive))
                return false;

            try
            {
                Path.GetDirectoryName(path + @"\"); // backlash because otherwise getDirName will c:\\foo\bazz as c:\\foo
            }
            catch (Exception e) when (e is ArgumentException || e is PathTooLongException)
            {
                return false;
            }
            return true;
        }
    }
}
