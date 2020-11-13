using System;

namespace VincreaserLib.VersionChangers
{
    public class FILE_assemblyInfo : IVersionChanger
    {
        private readonly string _versionFile = "AssemblyInfo.cs";

        public VersionChangerTypes Type => VersionChangerTypes.AssemblyInfo;

        public string[] GetVersionFiles(string path, string[] exclude = null)
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

        public void IncreasePatch(int i, string[] files)
        {
            throw new NotImplementedException();
        }

        public void SetVersion(string version, string[] files)
        {
            throw new NotImplementedException();
        }
    }
}
