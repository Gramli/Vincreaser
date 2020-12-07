using System;
using VincreaserLib.Exceptions;

namespace VincreaserLib.VincreaserCommands
{
    internal class IncreaseActionCommand : IIncreaseActionCommand
    {
        public string Name => "-increase";

        private IVersionChanger _versionChanger;

        private Action<IVersionFile, string> _runAction;

        public IncreaseActionCommand(IVersionChanger versionChanger)
        {
            _versionChanger = versionChanger;
        }

        public void Parse(string command)
        {
            var versions = command.Split(" ");

            if (versions.Length != 2)
            {
                throw new UnknownCommand($"You do not specify which part of version want to increase");
            }

            var type = versions[1];

            switch (type)
            {
                case "major":
                    _runAction = _versionChanger.IncreaseMajor; break;
                case "minor":
                    _runAction = _versionChanger.IncreaseMinor; break;
                case "build":
                    _runAction = _versionChanger.IncreaseBuild; break;
                case "revision":
                    _runAction = _versionChanger.IncreaseRevision; break;
                default:
                    throw new UnknownCommand($"Can't recognize version part: {type}");
            }
        }

        public void Run(IVersionFile versionFile, string filePaths)
        {
            _runAction(versionFile, filePaths);
        }
    }
}
