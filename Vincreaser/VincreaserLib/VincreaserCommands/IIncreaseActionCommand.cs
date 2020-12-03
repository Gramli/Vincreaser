using System;

namespace VincreaserLib.VincreaserCommands
{
    internal interface IIncreaseActionCommand : IVincreaserCommand
    {
        void Run(IVersionFile versionFile, string path, string[] exclude);
    }
}
