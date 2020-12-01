namespace VincreaserLib
{
    public interface IVersionFile
    {
        public VersionFileType Type { get; }
        public string[] GetVersionFiles(string path, string[] exclude = null);
        public void WriteAssemblyVersion(string version, string path);
        public string GetAssemblyVersion(string path);
        public string ExtractVersion(string line);
        public void Init(string directory, string name);
    }
}
