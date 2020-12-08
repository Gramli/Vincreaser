namespace VincreaserLib.VincreaserCommands
{
    internal interface IPathCommand : IVincreaserCommand
    {
        string[] GetPaths(IVersionFile versionFile);
    }

}
