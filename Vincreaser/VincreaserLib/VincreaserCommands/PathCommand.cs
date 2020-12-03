using System;

namespace VincreaserLib.VincreaserCommands
{
    internal class PathCommand : IPathCommand
    {
        public string Name => "-path";

        public void Parse(string command)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }
    }
}
