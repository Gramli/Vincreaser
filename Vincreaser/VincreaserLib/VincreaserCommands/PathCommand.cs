using System;
using System.Collections.Generic;
using System.Text;

namespace VincreaserLib.VincreaserCommands
{
    class PathCommand : IPathCommand
    {
        public string Name => "-path";

        public Func<string, string> GetPath()
        {
            throw new NotImplementedException();
        }
    }
}
