using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VersionChangers
{
    public class XML_csproj : IVersionChanger
    {
        private readonly string _versionFileExtension = ".csproj";

        public VersionChangerTypes Type => VersionChangerTypes.csproj;

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
