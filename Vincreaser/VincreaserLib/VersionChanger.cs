using System;

namespace VincreaserLib.VersionChangers
{
    public class VersionChanger : IVersionChanger
    {
        public void IncreaseMajor(IVersionFile versionFile, string[] files)
        {
            Increase(versionFile, files, (version) => new Version(version.Major + 1, version.Minor, version.Build, version.Revision));
        }

        public void IncreaseMinor(IVersionFile versionFile, string[] files)
        {
            Increase(versionFile, files, (version) => new Version(version.Major, version.Minor + 1, version.Build, version.Revision));
        }

        public void IncreaseBuild( IVersionFile versionFile, string[] files)
        {
            Increase(versionFile, files, (version) => new Version(version.Major, version.Minor, version.Build + 1, version.Revision));
        }

        public void IncreaseRevision( IVersionFile versionFile, string[] files)
        {
            Increase(versionFile, files, (version) => new Version(version.Major, version.Minor, version.Build, version.Revision + 1));
        }

        public void SetVersion(string version, IVersionFile versionFile, string[] files)
        {
            foreach (var file in files)
            {
                var newVersion = new Version(version);
                versionFile.WriteAssemblyVersion(newVersion.ToString(), file);
            }
        }

        private void Increase(IVersionFile versionFile, string[] files, Func<Version, Version> increaseFunc)
        {
            foreach (var file in files)
            {
                var versionString = versionFile.GetAssemblyVersion(file);
                var version = new Version(versionString);
                var newVersion = increaseFunc(version);
                versionFile.WriteAssemblyVersion(newVersion.ToString(), file);
            }
        }

        public void Init(IVersionFile versionFile, string[] files)
        {
            throw new NotImplementedException();
        }
    }
}
