using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    class IncreaseActionCommand : ActionCommand
    {
        public string Name => "-increase";

        public IncreaseActionCommand(string command)
        {
            Parse(command);
        }

        private void Parse(string command)
        {
            throw new NotImplementedException();
        }

        public void Run(IVersionFile versionFile, string path, string[] exclude)
        {
            throw new NotImplementedException();
        }
    }
}
