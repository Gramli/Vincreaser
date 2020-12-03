using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    internal class File_assemblyInfocs : IVersionFile
    {
        public VersionFileType Type => VersionFileType.assemblyInfocs;

        private readonly string _versionFile = "AssemblyInfo.cs";

        private readonly IDirectoryBrowser _directoryBrowser;
        public File_assemblyInfocs(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }

        public string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, exclude).ToArray();
        }

        public void WriteAssemblyVersion(string version, string path)
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

                if (line.Contains("AssemblyVersion"))
                {
                    var oldVersion = ExtractVersion(line);
                    line = line.Replace(oldVersion, version);
                    lines.Add(line);
                    continue;
                }

                lines.Add(line);
            }

            if (lines.Count == 0)
            {
                throw new IOException("File is empty, can't read AssemblyVersion");
            }

            File.WriteAllLines(path, lines);
        }

        public string GetAssemblyVersion(string path)
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

        public string ExtractVersion(string line)
        {
            var leftBracketIndex = line.IndexOf(")");
            var rightBracketIndex = line.IndexOf(")");

            return line.Substring(leftBracketIndex, rightBracketIndex - leftBracketIndex);
        }

        public void Init(string name, string directory)
        {
            var path = Path.Combine(directory, _versionFile);
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine($"[assembly: AssemblyTitle(\"{name}\")]");
            streamWriter.WriteLine($"[assembly: AssemblyVersion(\"1.0.0.0\")]");
        }
    }
}
