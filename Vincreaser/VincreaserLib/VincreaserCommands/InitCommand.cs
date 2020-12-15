using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VincreaserLib.Exceptions;
using VincreaserLib.Extensions;

namespace VincreaserLib.VincreaserCommands
{
    public class InitCommand : IInitActionCommand
    {
        public string Name => "-init";

        private string projectName;

        public void Parse(string command)
        {
            var versions = command.SplitAndRemoveSpaces(' ');

            if (versions.Length != 1)
            {
                throw new UnknownCommand($"You do not specify project name for init command");
            }

            projectName = versions[0];
        }

        public string Run(IVersionFile versionFile, string dirPath)
        {
            return versionFile.Init(dirPath, projectName);
        }
    }
}
