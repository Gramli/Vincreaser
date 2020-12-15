using System.Linq;
using VincreaserLib.Exceptions;
using VincreaserLib.Extensions;

namespace VincreaserLib.VincreaserCommands
{
    internal class PathCommand : IPathCommand
    {
        public string Name => "-path";

        private string _path;

        private readonly IDirectoryBrowser _directoryBrowser;

        public PathCommand(IDirectoryBrowser directoryBrowser)
        {
            _directoryBrowser = directoryBrowser;
        }

        public void Parse(string command)
        {
            var setSplit = command.SplitAndRemoveSpaces(' ');

            if (setSplit.Length != 1)
            {
                throw new PathException($"Something missing in {Name} command.");
            }

            _path = setSplit[0];
        }

        public string[] GetPaths(IVersionFile versionFile)
        {
            if (_directoryBrowser.IsDirectory(_path))
            {
                var files = versionFile.GetVersionFiles(_path);
                return files.Any() ? files : new[] { _path};
            }

            if (_directoryBrowser.IsFile(_path))
            {
                return new[] {_path};
            }

            throw new PathException($"Can't recognize path: {_path}");
        }
    }
}
