using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VincreaserLib.Extensions;

namespace VincreaserLib.VersionFiles
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

        public string[] GetVersionFiles(string path)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile).ToArray();
        }

        public void WriteAssemblyVersion(string version, string path)
        {
            var lines = new List<string>();
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var textReader = new StreamReader(fileStream);
            while (true)
            {
                var line = textReader.ReadLine();
                if (line is null)
                {
                    break;
                }

                if (IsVersionLine(line))
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
            using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var textReader = new StreamReader(fileStream);
            while (true)
            {
                var line = textReader.ReadLine();
                if (line is null)
                {
                    break;
                }

                if (IsVersionLine(line))
                {
                    result = ExtractVersion(line);
                    break;
                }
            }

            return result;
        }

        public string ExtractVersion(string line)
        {
            var leftBracketIndex = line.IndexOf("(", StringComparison.Ordinal) +1 ;
            var rightBracketIndex = line.IndexOf(")", StringComparison.Ordinal);
            return line.Substring(leftBracketIndex, rightBracketIndex - leftBracketIndex).ReplaceQuotesAndBackslashes();
        }

        public string Init(string directory, string name)
        {
            var path = _directoryBrowser.IsFile(directory) ? directory : Path.Combine(directory, _versionFile);
            using var fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine($"[assembly: AssemblyTitle(\"{name}\")]");
            streamWriter.WriteLine($"[assembly: Guid(\"{Guid.NewGuid()}\")]");
            streamWriter.WriteLine($"[assembly: AssemblyVersion(\"1.0.0.0\")]");

            return path;
        }

        private bool IsVersionLine(string line)
        {
            return line.StartsWith("[assembly: AssemblyVersion");
        }
    }
}
