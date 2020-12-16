using System;

namespace VincreaserLib.VersionChangers
{
    internal class VersionChanger : IVersionChanger
    {
        public string IncreaseMajor(IVersionFile versionFile, string file)
        {
            return Increase(versionFile, file, (version) => new Version(version.Major + 1, 0, 0, 0));
        }

        public string IncreaseMinor(IVersionFile versionFile, string file)
        {
            return Increase(versionFile, file, (version) => new Version(version.Major, version.Minor + 1, 0, 0));
        }

        public string IncreaseBuild(IVersionFile versionFile, string file)
        {
            return Increase(versionFile, file, (version) => new Version(version.Major, version.Minor, version.Build + 1, 0));
        }

        public string IncreaseRevision(IVersionFile versionFile, string file)
        {
            return Increase(versionFile, file, (version) => new Version(version.Major, version.Minor, version.Build, version.Revision + 1));
        }

        public string SetVersion(string version, IVersionFile versionFile, string file)
        {
            var newVersion = new Version(version).ToString();
            versionFile.WriteAssemblyVersion(newVersion, file);
            return newVersion;
        }

        private string Increase(IVersionFile versionFile, string file, Func<Version, Version> increaseFunc)
        {
            var versionString = versionFile.GetAssemblyVersion(file);
            var version = new Version(versionString);
            var newVersion = increaseFunc(version).ToString();
            versionFile.WriteAssemblyVersion(newVersion, file);
            return newVersion;
        }

        public string Init(IVersionFile versionFile, string file)
        {
            throw new NotImplementedException();
        }
    }
}
