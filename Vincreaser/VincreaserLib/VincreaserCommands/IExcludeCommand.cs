namespace VincreaserLib.VincreaserCommands
{
    internal interface IExcludeCommand : IVincreaserCommand
    {
        string[] GetExclude();
    }
}
