using System;

namespace VincreaserLib.VincreaserCommands
{
    internal class TypeCommand : ITypeCommand
    {
        public string Name => "-type";

        public IVersionFile GetVersionFile()
        {
            throw new NotImplementedException();
        }

        public void Parse(string command)
        {
            throw new NotImplementedException();
        }
    }
}
