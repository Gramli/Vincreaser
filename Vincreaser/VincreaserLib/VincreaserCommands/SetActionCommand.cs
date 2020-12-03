using System;

namespace VincreaserLib.VincreaserCommands
{
    internal class SetActionCommand : ISetActionCommand
    {
        public string Name => "-set";

        public SetActionCommand(string command)
        {
            Parse(command);
        }

        public void Parse(string command)
        {
            throw new NotImplementedException();
        }

        public void Run(IVersionFile versionFile, string path, string[] exclude)
        {
            throw new NotImplementedException();
        }
    }
}
