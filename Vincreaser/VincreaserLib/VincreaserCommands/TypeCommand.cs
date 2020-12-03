using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    class TypeCommand : ITypeCommand
    {
        public string Name => "-type";

        public IVersionFile GetVersionFile()
        {
            throw new NotImplementedException();
        }
    }
}
