using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    interface ITypeCommand : IVincreaserCommand
    {
        Func<string, IVersionFile> GetVersionFile();
    }
}
