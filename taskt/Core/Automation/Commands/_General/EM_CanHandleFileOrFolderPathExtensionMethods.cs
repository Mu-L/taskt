using System.IO;

namespace taskt.Core.Automation.Commands
{
    public static class EM_CanHandleFileOrFolderPathExtensionMethods
    {
        /// <summary>
        /// check file/folder path is full-path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsFullPath(string path)
        {
            return !string.IsNullOrEmpty(Path.GetPathRoot(path));
        }

        /// <summary>
        /// check file path is URL
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsURL(string path)
        {
            return (path.StartsWith("http:") || path.StartsWith("https:"));
        }

        /// <summary>
        /// check string is valid path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsValidPathString(string path)
        {
            var invs = Path.GetInvalidPathChars();
            return (path.IndexOfAny(invs) < 0);
        }
    }
}
