using System;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    public class File_versiongo : IVersionChanger
    {
        private readonly string _versionFile = "version.go";

        public VersionChangerTypes Type => VersionChangerTypes.versiongo;

        private readonly IDirectoryBrowser _directoryBrowser;
        public File_versiongo(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }
        public string[] GetVersionFiles(string path, string[] excludeDirs = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, excludeDirs).ToArray();
        }

        public void IncreaseBuild(int i, string[] files)
        {
            throw new NotImplementedException();
        }

        public void IncreaseMajor(int i, string[] files)
        {
            throw new NotImplementedException();
        }

        public void IncreaseMinor(int i, string[] files)
        {
            throw new NotImplementedException();
        }

        public void IncreaseRevision(int i, string[] files)
        {
            throw new NotImplementedException();
        }

        public void SetVersion(string version, string[] files)
        {
            throw new NotImplementedException();
        }
    }
}
