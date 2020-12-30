using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VincreaserLib.Extensions;

namespace VincreaserLib.VersionFiles
{
    internal class File_versiongo : IVersionFile
    {
        private readonly string _versionFile = "version.go";

        private readonly IDirectoryBrowser _directoryBrowser;

        public VersionFileType Type => VersionFileType.versiongo;

        public File_versiongo(IDirectoryBrowser directoryBrowser)
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
                    line = line.Replace($"\"{oldVersion}\"", $"\"{version}\"", StringComparison.Ordinal);
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
            var indexOfEquation = line.IndexOf("=", StringComparison.Ordinal) + 1;
            return line.Substring(indexOfEquation, line.Length - indexOfEquation).ReplaceQuotesAndBackslashes();
        }

        public string Init(string directory, string name)
        {
            var path = _directoryBrowser.IsFile(directory) ? directory : Path.Combine(directory, _versionFile);
            using var fileStream = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("package main");
            streamWriter.WriteLine();
            streamWriter.WriteLine($"var projectName = \"{name}\"");
            streamWriter.WriteLine($"var version = \"1.0.0.0\"");
            streamWriter.WriteLine($"var goVersion = \"{GetGolangVersion()}\"");
            streamWriter.WriteLine($"var changeDate = \"{DateTime.Now}\"");

            return path;
        }

        private string GetGolangVersion()
        {
            var result = string.Empty;

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    Arguments = "go version",
                }
            };

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => { result += e.Data; };

            return result;
        }

        private bool IsVersionLine(string line)
        {
            return line.StartsWith("var version =");
        }
    }
}
