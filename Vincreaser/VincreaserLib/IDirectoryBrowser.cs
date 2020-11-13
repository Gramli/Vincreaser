namespace VincreaserLib
{
    public interface IDirectoryBrowser
    {
        bool IsFile(string path);
        bool IsDirectory(string path);
        string[] GetFilesByName(string sourceDirectory, string fileName);
        string[] GetFilesByExtension(string sourceDirectory, string extension);
    }
}
