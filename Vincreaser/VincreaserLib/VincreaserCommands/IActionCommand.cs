namespace VincreaserLib.VincreaserCommands
{
    internal interface IActionCommand : IVincreaserCommand
    {
        void Run(IVersionFile versionFile, string filePath);
    }
}
