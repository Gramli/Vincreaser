using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace VincreaserLib.VersionChangers
{
    public class XML_csproj : VersionChangerBase
    {
        private readonly string _versionFileExtension = ".csproj";

        private readonly string _propertyGroupElementName = "PropertyGroup";

        private readonly string _assemblyVersionElementName = "AssemblyVersion";

        public override VersionChangerTypes Type => VersionChangerTypes.csproj;

        private readonly IDirectoryBrowser _directoryBrowser;
        public XML_csproj(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }
        public override string[] GetVersionFiles(string path, string[] exclude = null)
        {
            return _directoryBrowser.GetFilesByExtension(path, _versionFileExtension, exclude).ToArray();
        }

        protected override string GetAssemblyVersion(string file)
        {
            var projectElement = XElement.Load(file);
            var propertyGroupElement = projectElement.Element(_propertyGroupElementName);
            var assemblyVersionElement = propertyGroupElement.Element(_assemblyVersionElementName);
            return assemblyVersionElement.Value;
        }

        protected override void WriteAssemblyVersion(string version, string file)
        {
            var projectElement = XElement.Load(file);
            var propertyGroupElement = projectElement.Element(_propertyGroupElementName);
            var assemblyVersionElement = propertyGroupElement.Element(_assemblyVersionElementName);
            assemblyVersionElement.Value = version;
            File.WriteAllText(file, projectElement.ToString());
        }
    }
}
