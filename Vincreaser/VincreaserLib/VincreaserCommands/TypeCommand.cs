using System;
using System.Collections.Generic;
using System.Linq;
using VincreaserLib.Exceptions;
using VincreaserLib.Extensions;

namespace VincreaserLib.VincreaserCommands
{
    internal class TypeCommand : ITypeCommand
    {
        public string Name => "-type";

        private string _type;

        private readonly IEnumerable<IVersionFile> _versionFiles;

        public TypeCommand(IEnumerable<IVersionFile> versionFiles)
        {
            _versionFiles = versionFiles;
        }

        public IVersionFile GetVersionFile()
        {
            var versionFileType = _type.GetVersionFileType();
            return _versionFiles.Single(i => i.Type == versionFileType);
        }

        public void Parse(string command)
        {
            var setSplit = command.SplitAndRemoveSpaces(' ');

            if (setSplit.Length != 1)
            {
                throw new PathException($"Something missing in {Name} command.");
            }

            _type = setSplit[0];
        }
    }
}
