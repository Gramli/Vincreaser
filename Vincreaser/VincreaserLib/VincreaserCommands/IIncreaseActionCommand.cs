using System;

namespace VincreaserLib.VincreaserCommands
{
    internal interface ActionCommand : IVincreaserCommand
    {
        void Run(IVersionFile versionFile, string path, string[] exclude);
    }
}
