﻿using System;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    public class XML_csproj : IVersionChanger
    {
        private readonly string _versionFileExtension = ".csproj";

        public VersionChangerTypes Type => VersionChangerTypes.csproj;

        private readonly IDirectoryBrowser _directoryBrowser;
        public XML_csproj(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }
        public string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByExtension(path, _versionFileExtension, exclude).ToArray();
        }

        public void SetVersion(string version, string[] files)
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

        public void IncreaseBuild(int i, string[] files)
        {
            throw new NotImplementedException();
        }

        public void IncreaseRevision(int i, string[] files)
        {
            throw new NotImplementedException();
        }
    }
}
