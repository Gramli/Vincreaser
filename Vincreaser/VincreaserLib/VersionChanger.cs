using System;

namespace VincreaserLib.VersionChangers
{
    internal class VersionChanger : IVersionChanger
    {
        public void IncreaseMajor(IVersionFile versionFile, string file)
        {
            Increase(versionFile, file, (version) => new Version(version.Major + 1, version.Minor, version.Build, version.Revision));
        }

        public void IncreaseMinor(IVersionFile versionFile, string file)
        {
            Increase(versionFile, file, (version) => new Version(version.Major, version.Minor + 1, version.Build, version.Revision));
        }

        public void IncreaseBuild(IVersionFile versionFile, string file)
        {
            Increase(versionFile, file, (version) => new Version(version.Major, version.Minor, version.Build + 1, version.Revision));
        }

        public void IncreaseRevision(IVersionFile versionFile, string file)
        {
            Increase(versionFile, file, (version) => new Version(version.Major, version.Minor, version.Build, version.Revision + 1));
        }

        public void SetVersion(string version, IVersionFile versionFile, string file)
        {
            var newVersion = new Version(version);
            versionFile.WriteAssemblyVersion(newVersion.ToString(), file);

        }

        private void Increase(IVersionFile versionFile, string file, Func<Version, Version> increaseFunc)
        {
            var versionString = versionFile.GetAssemblyVersion(file);
            var version = new Version(versionString);
            var newVersion = increaseFunc(version);
            versionFile.WriteAssemblyVersion(newVersion.ToString(), file);
        }

        public void Init(IVersionFile versionFile, string file)
        {
            throw new NotImplementedException();
        }
    }
}
