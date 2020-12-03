using System;

namespace VincreaserLib.VincreaserCommands
{
    internal interface IExcludeCommand : IVincreaserCommand
    {
        string[] GetExclude();
    }
}
