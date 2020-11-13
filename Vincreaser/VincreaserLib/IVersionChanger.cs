namespace VincreaserLib
{
    interface IVersionChanger
    {
        VersionChangerTypes Type { get; }
        string[] GetVersionFiles(string path, string[] exclude = null);
        void SetVersion(string version, string[] files);
        void IncreaseMajor(int i, string[] files);
        void IncreaseMinor(int i, string[] files);
        void IncreasePatch(int i, string[] files);

    }
}
