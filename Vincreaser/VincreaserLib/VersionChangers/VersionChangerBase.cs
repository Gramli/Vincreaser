using System;

namespace VincreaserLib.VersionChangers
{
    public abstract class VersionChangerBase : IVersionChanger
    {
        public abstract VersionChangerTypes Type { get; }

        public void IncreaseMajor(int i, string[] files)
        {
            Increase(i, files, (version, i) => new Version(version.Major + i, version.Minor, version.Build, version.Revision));
        }

        public void IncreaseMinor(int i, string[] files)
        {
            Increase(i, files, (version, i) => new Version(version.Major, version.Minor + i, version.Build, version.Revision));
        }

        public void IncreaseBuild(int i, string[] files)
        {
            Increase(i, files, (version, i) => new Version(version.Major, version.Minor, version.Build + i, version.Revision));
        }

        public void IncreaseRevision(int i, string[] files)
        {
            Increase(i, files, (version, i) => new Version(version.Major, version.Minor, version.Build, version.Revision + i));
        }

        public void SetVersion(string version, string[] files)
        {
            foreach (var file in files)
            {
                var newVersion = new Version(version);
                WriteAssemblyVersion(newVersion.ToString(), file);
            }
        }

        private void Increase(int i, string[] files, Func<Version, int, Version> increaseFunc)
        {
            foreach (var file in files)
            {
                var versionString = GetAssemblyVersion(file);
                var version = new Version(versionString);
                var newVersion = increaseFunc(version, i);
                WriteAssemblyVersion(newVersion.ToString(), file);
            }
        }

        public abstract string[] GetVersionFiles(string path, string[] excludeDirs = null);
        protected abstract void WriteAssemblyVersion(string version, string path);
        protected abstract string GetAssemblyVersion(string path);
    }
}
