using System;

namespace VincreaserLib.VincreaserCommands
{
    internal class IncreaseActionCommand : IIncreaseActionCommand
    {
        public string Name => "-increase";

        public IncreaseActionCommand(string command)
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
