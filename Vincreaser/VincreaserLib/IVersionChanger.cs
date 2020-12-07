namespace VincreaserLib
{
    public interface IVersionChanger
    {
        void SetVersion(string version, IVersionFile versionFile, string file);
        void IncreaseMajor(IVersionFile versionFile, string file);
        void IncreaseMinor( IVersionFile versionFile, string file);
        void IncreaseBuild(IVersionFile versionFile, string file);
        void IncreaseRevision(IVersionFile versionFile, string file);
        void Init(IVersionFile versionFile, string file);
    }
}
