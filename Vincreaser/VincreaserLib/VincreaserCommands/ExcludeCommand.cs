using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    class ExcludeCommand : IExcludeCommand
    {
        public string Name => "-exclude";

        public Func<string, string[]> GetExclude()
        {
            throw new NotImplementedException();
        }
    }
}
