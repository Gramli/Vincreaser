using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    public class File_assemblyInfocs : IVersionChanger
    {
        private readonly string _versionFile = "AssemblyInfo.cs";

        public VersionChangerTypes Type => VersionChangerTypes.assemblyInfocs;

        private readonly IDirectoryBrowser _directoryBrowser;
        public File_assemblyInfocs(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }

        public string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, exclude).ToArray();
        }

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

        private void WriteAssemblyVersion(string version, string path)
        {
            var lines = new List<string>();
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Read);
            using var textReader = new StreamReader(fileStream);
            while (true)
            {
                var line = textReader.ReadLine();
                if (line is null)
                {
                    break;
                }

                if(line.Contains("AssemblyVersion"))
                {
                    var oldVersion = ExtractVersion(line);
                    line = line.Replace(oldVersion, version);
                    lines.Add(line);
                    continue;
                }

                lines.Add(line);
            }

            if(lines.Count == 0)
            {
                throw new IOException("File is empty, can't read AssemblyVersion");
            }

            File.WriteAllLines(path, lines);
        }



        private string GetAssemblyVersion(string path)
        {
            var result = string.Empty;
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var textReader = new StreamReader(fileStream);
            while (true)
            {
                var line = textReader.ReadLine();
                if (line is null)
                {
                    break;
                }

                if (line.Contains("AssemblyVersion"))
                {
                    result = ExtractVersion(line);
                    break;
                }
            }

            return result;
        }

        private string ExtractVersion(string line)
        {
            var leftBracketIndex = line.IndexOf(")");
            var rightBracketIndex = line.IndexOf(")");

            return line.Substring(leftBracketIndex, rightBracketIndex - leftBracketIndex);
        }
    }
}
