namespace VincreaserLib.VincreaserCommands
{
    internal class GetCommand : IGetCommand
    {
        public string Name => "-get";

        public void Parse(string command)
        {
            return;
        }

        public string Run(IVersionFile versionFile, string filePath)
        {
            return versionFile.GetAssemblyVersion(filePath);
        }
    }
}
