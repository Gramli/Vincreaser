namespace VincreaserLib
{
    public interface IVersionChanger
    {
        string SetVersion(string version, IVersionFile versionFile, string file);
        string IncreaseMajor(IVersionFile versionFile, string file);
        string IncreaseMinor( IVersionFile versionFile, string file);
        string IncreaseBuild(IVersionFile versionFile, string file);
        string IncreaseRevision(IVersionFile versionFile, string file);
    }
}
