using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    public class File_assemblyInfocs : VersionChangerBase
    {
        private readonly string _versionFile = "AssemblyInfo.cs";

        public override VersionChangerTypes Type => VersionChangerTypes.assemblyInfocs;

        private readonly IDirectoryBrowser _directoryBrowser;
        public File_assemblyInfocs(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }

        public override string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, exclude).ToArray();
        }

        protected override void WriteAssemblyVersion(string version, string path)
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



        protected override string GetAssemblyVersion(string path)
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
