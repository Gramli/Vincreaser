using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace VincreaserLib.VersionChangers
{
    //init in every finded csproj
    //init in folder
    public class XML_csproj : IVersionFile
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
        public string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByExtension(path, _versionFileExtension, exclude).ToArray();
        }

        public string GetAssemblyVersion(string file)
        {
            var projectElement = XElement.Load(file);
            var propertyGroupElement = projectElement.Element(_propertyGroupElementName);
            var assemblyVersionElement = propertyGroupElement.Element(_assemblyVersionElementName);
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

        public void Init(string directory)
        {
            throw new NotImplementedException();
        }
    }
}
