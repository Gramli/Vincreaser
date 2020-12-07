using VincreaserLib.Exceptions;

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
            var setSplit = command.Split(" ");

            if (setSplit.Length != 2)
            {
                throw new UnknownCommand($"Something missing in {Name} command.");
            }

            _version = setSplit[1];

        }

        public void Run(IVersionFile versionFile, string path)
        {
            _versionChanger.SetVersion(_version, versionFile, path);
        }
    }
}
