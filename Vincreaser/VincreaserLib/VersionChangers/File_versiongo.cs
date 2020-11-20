using System;
using System.IO;
using System.Linq;

namespace VincreaserLib.VersionChangers
{
    public class File_versiongo : VersionChangerBase
    {
        private readonly string _versionFile = "version.go";

        public override VersionChangerTypes Type => VersionChangerTypes.versiongo;

        private readonly IDirectoryBrowser _directoryBrowser;
        public File_versiongo(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }
        public override string[] GetVersionFiles(string path, string[] excludeDirs = null)
        {
            return _directoryBrowser.GetFilesByName(path, _versionFile, excludeDirs).ToArray();
        }

        protected override void WriteAssemblyVersion(string version, string path)
        {
            throw new NotImplementedException();
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

                if (line.Contains("version"))
                {
                    result = ExtractVersion(line);
                    break;
                }
            }

            return result;

        }

        private string ExtractVersion(string line)
        {
            var indexOfEquation = line.IndexOf("=");
            return line.Substring(indexOfEquation, line.Length - indexOfEquation);
        }
    }
}
