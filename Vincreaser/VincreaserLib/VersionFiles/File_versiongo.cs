using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
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
        public string[] GetVersionFiles(string path, string[] excludeDirs = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, excludeDirs).ToArray();
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

                if (line.Contains("version"))
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

                if (line.Contains("version"))
                {
                    result = ExtractVersion(line);
                    break;
                }
            }

            return result;

        }

        public string ExtractVersion(string line)
        {
            var indexOfEquation = line.IndexOf("=");
            return line.Substring(indexOfEquation, line.Length - indexOfEquation);
        }

        public void Init(string name, string directory)
        {
            var path = Path.Combine(directory, _versionFile);
            using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("package main");
            streamWriter.WriteLine();
            streamWriter.WriteLine($"var version = \"1.0.0.0\"");
            streamWriter.WriteLine($"var goVersion = \"{GetGolangVersion()}\"");
            streamWriter.WriteLine($"var changeDate = \"{DateTime.Now}\"");
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
    }
}
