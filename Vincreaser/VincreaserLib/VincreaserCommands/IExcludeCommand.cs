using System;

namespace VincreaserLib.VincreaserCommands
{
    internal interface IExcludeCommand : IVincreaserCommand
    {
        Func<string, string[]> GetExclude();
    }
}
