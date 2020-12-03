using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    interface IPathCommand : IVincreaserCommand
    {
        string GetPath();
    }

}
