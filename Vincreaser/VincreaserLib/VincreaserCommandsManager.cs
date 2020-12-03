using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib
{
    class VincreaserCommandsManager : IVincreaserCommandsManager
    {
        private readonly IEnumerable<Func<IVincreaserCommand>> _commands;

        public VincreaserCommandsManager(IEnumerable<Func<IVincreaserCommand>> commands)
        {

        }

        public IVincreaserCommand GetCommand(string command)
        {
            
        }
    }
}
