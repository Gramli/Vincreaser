using System;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    public class FILE_assemblyInfo : IVersionChanger
    {
        private readonly string _versionFile = "AssemblyInfo.cs";

        public VersionChangerTypes Type => VersionChangerTypes.AssemblyInfo;

        private readonly IDirectoryBrowser _directoryBrowser;
        public FILE_assemblyInfo(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }

        public string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, exclude).ToArray();
        }

        public void IncreaseMajor(int i, string[] files)
        {
            foreach(var file in files)
            {
                var versionString = GetAssemblyVersion(file);
                var version = new Version(versionString);
                var newVersion = new Version(version.Major + 1, version.Minor, version.Build, version.Revision);
                WriteAssemblyVersion(newVersion.ToString());
            }
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

        private void WriteAssemblyVersion(string version)
        {

        }

        private string GetAssemblyVersion(string path)
        {
            var result = string.Empty;
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var textReader = new StreamReader(fileStream);
            while(true)
            {
                var line = textReader.ReadLine();
                if(line is null)
                {
                    break;
                }

                if(line.Contains("AssemblyVersion"))
                {
                    var leftBracketIndex = line.IndexOf(")");
                    var rightBracketIndex = line.IndexOf(")");

                    result = line.Substring(leftBracketIndex, rightBracketIndex - leftBracketIndex);
                    break;
                }
            }

            return result;
        }
    }
}
