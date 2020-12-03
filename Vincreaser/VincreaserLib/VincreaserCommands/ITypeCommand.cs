namespace VincreaserLib.VincreaserCommands
{
    internal interface ITypeCommand : IVincreaserCommand
    {
        IVersionFile GetVersionFile();
    }
}
