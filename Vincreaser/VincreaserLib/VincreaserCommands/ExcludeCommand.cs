using System;

namespace VincreaserLib.VincreaserCommands
{
    internal class ExcludeCommand : IExcludeCommand
    {
        public string Name => "-exclude";

        public void Parse(string command)
        {
            throw new NotImplementedException();
        }

        public string[] GetExclude()
        {
            throw new NotImplementedException();
        }
    }
}
