using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VincreaserLib
{
    internal class DirectoryBrowser : IDirectoryBrowser
    {
        public IList<string> GetFilesByExtension(string sourceDirectory, string extension, IEnumerable<string> directoriesToExclude = null)
        {
            var result = Directory.GetFiles(sourceDirectory).Where(file => Path.GetExtension(file) == extension).ToList();

            var subDirFiles = GetFilesInSubDirectories(sourceDirectory, extension, directoriesToExclude, GetFilesByExtension);
            if (subDirFiles.Any())
            {
                result.AddRange(subDirFiles);
            }

            return result;
        }

        public IList<string> GetFilesByName(string sourceDirectory, string fileName, IEnumerable<string> directoriesToExclude = null)
        {
            var result = new List<string>();

            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                if (Path.GetFileName(file) == fileName)
                {
                    result.Add(file);
                }
            }

            var subDirFiles = GetFilesInSubDirectories(sourceDirectory, fileName, directoriesToExclude, GetFilesByName);
            if(subDirFiles.Count > 0)
            {
                result.AddRange(subDirFiles);
            }

            return result;
        }

        public bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public bool IsFile(string path)
        {
            return File.Exists(path);
        }

        private IList<string> GetFilesInSubDirectories(string sourceDirectory, string compare, IEnumerable<string> directoriesToExclude, Func<string, string, IEnumerable<string>, IList<string>> getFilesFunc)
        {
            var result = new List<string>();

            foreach (var dir in Directory.GetDirectories(sourceDirectory))
            {
                if (directoriesToExclude != null && directoriesToExclude.Contains(Path.GetDirectoryName(dir)))
                {
                    continue;
                }

                var recursiveFiles = getFilesFunc(dir, compare, directoriesToExclude);
                if (recursiveFiles != null && recursiveFiles.Any())
                {
                    result.AddRange(recursiveFiles);
                }
            }

            return result;
        }
    }
}
