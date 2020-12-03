using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib
{
    interface IVincreaserCommandsManager
    {
        IVincreaserCommand GetCommand(string command);
    }
}
