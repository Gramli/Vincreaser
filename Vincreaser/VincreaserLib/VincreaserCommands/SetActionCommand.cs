using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    class SetActionCommand : ActionCommand
    {
        public string Name => "-set";

        public SetActionCommand(string command)
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
