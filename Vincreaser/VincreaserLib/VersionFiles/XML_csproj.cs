﻿using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace VincreaserLib.VersionFiles
{
    internal class XML_csproj : IVersionFile
    {
        public VersionFileType Type => VersionFileType.csproj;

        private readonly string _versionFileExtension = ".csproj";

        private readonly string _propertyGroupElementName = "PropertyGroup";

        private readonly string _assemblyVersionElementName = "AssemblyVersion";

        private readonly IDirectoryBrowser _directoryBrowser;
        public XML_csproj(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }
        public string[] GetVersionFiles(string path)
        {
            return _directoryBrowser.GetFilesByExtension(path, _versionFileExtension).ToArray();
        }

        public string GetAssemblyVersion(string file)
        {
            var projectElement = XElement.Load(file);
            var propertyGroupElement = projectElement?.Element(_propertyGroupElementName);
            var assemblyVersionElement = propertyGroupElement?.Element(_assemblyVersionElementName);

            if(assemblyVersionElement is null)
            {
                throw new FileLoadException($"Can't load {_assemblyVersionElementName} element.");
            }

            return assemblyVersionElement.Value;
        }

        public void WriteAssemblyVersion(string version, string file)
        {
            var projectElement = XElement.Load(file);
            var propertyGroupElement = projectElement.Element(_propertyGroupElementName);
            var assemblyVersionElement = propertyGroupElement.Element(_assemblyVersionElementName);
            assemblyVersionElement.Value = version;
            File.WriteAllText(file, projectElement.ToString());
        }

        public string ExtractVersion(string elementValue)
        {
            return elementValue;
        }
        public string Init(string directory, string name)
        {
            var file = directory;
            if (_directoryBrowser.IsDirectory(directory))
            {
                file = _directoryBrowser.GetFilesByExtension(directory, _versionFileExtension, null)
                .Single(item => Path.GetFileNameWithoutExtension(item).Equals(name));
            }

            if(!File.Exists(file))
            {
                throw new FileNotFoundException(file);
            }

            var projectElement = XElement.Load(file);
            if(projectElement is null)
            {
                throw new FileLoadException($"Can't load Project element.");
            }

            var propertyGroupElement = projectElement.Element(_propertyGroupElementName);
            if(propertyGroupElement is null)
            {
                propertyGroupElement = new XElement(_propertyGroupElementName);
                propertyGroupElement.Add(new XElement(_assemblyVersionElementName));
                projectElement.Add(propertyGroupElement);
            }

            var assemblyVersionElement = propertyGroupElement.Element(_assemblyVersionElementName);
            if(assemblyVersionElement is null)
            {
                assemblyVersionElement = new XElement(_assemblyVersionElementName);
                propertyGroupElement.Add(assemblyVersionElement);
            }

            assemblyVersionElement.Value = "1.0.0.0";
            File.WriteAllText(file, projectElement.ToString());

            return file;
        }
    }
}
