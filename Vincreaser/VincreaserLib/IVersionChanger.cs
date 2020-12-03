namespace VincreaserLib
{
    public interface IVersionChanger
    {
        void SetVersion(string version, IVersionFile versionFile, string[] files);
        void IncreaseMajor(IVersionFile versionFile, string[] files);
        void IncreaseMinor( IVersionFile versionFile, string[] files);
        void IncreaseBuild(IVersionFile versionFile, string[] files);
        void IncreaseRevision(IVersionFile versionFile, string[] files);
        void Init(IVersionFile versionFile, string[] files);
    }
}
