using System.Collections.Generic;

namespace VincreaserLib
{
    public interface IDirectoryBrowser
    {
        bool IsFile(string path);
        bool IsDirectory(string path);
        IList<string> GetFilesByName(string sourceDirectory, string fileName, IEnumerable<string> directoriesToExclude = null);
        IList<string> GetFilesByExtension(string sourceDirectory, string extension, IEnumerable<string> directoriesToExclude = null);
    }
}
