namespace VincreaserLib
{
    public interface IVincreaserCommand
    {
        string Name { get; }

        void Parse(string command);
    }
}
