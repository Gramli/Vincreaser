namespace VincreaserLib.VincreaserCommands
{
    internal interface IActionCommand : IVincreaserCommand
    {
        string Run(IVersionFile versionFile, string filePath);
    }
}
