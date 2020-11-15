namespace VincreaserLib
{
    interface IVersionChanger
    {
        VersionChangerTypes Type { get; }
        string[] GetVersionFiles(string path, string[] excludeDirs = null);
        void SetVersion(string version, string[] files);
        void IncreaseMajor(int i, string[] files);
        void IncreaseMinor(int i, string[] files);
        void IncreaseBuild(int i, string[] files);
        void IncreaseRevision(int i, string[] files);

    }
}
