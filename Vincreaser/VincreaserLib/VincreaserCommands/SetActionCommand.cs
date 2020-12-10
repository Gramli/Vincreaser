using VincreaserLib.Exceptions;
using VincreaserLib.Extensions;

namespace VincreaserLib.VincreaserCommands
{
    internal class SetActionCommand : ISetActionCommand
    {
        public string Name => "-set";

        private string _version;

        private readonly IVersionChanger _versionChanger;

        public SetActionCommand(IVersionChanger versionChanger)
        {
            _versionChanger = versionChanger;
        }

        public void Parse(string command)
        {
            var setSplit = command.SplitAndRemoveSpaces(' ');

            if (setSplit.Length != 1)
            {
                throw new UnknownCommand($"Something missing in {Name} command.");
            }

            _version = setSplit[0];

        }

        public string Run(IVersionFile versionFile, string path)
        {
            return _versionChanger.SetVersion(_version, versionFile, path);
        }
    }
}
