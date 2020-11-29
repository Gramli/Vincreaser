using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    //init in folder
    // init - with golang version
    // init - add last change date
    public class File_versiongo : IVersionFile
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

        public void Init(string directory)
        {
            throw new NotImplementedException();
        }
    }
}
