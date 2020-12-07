using VincreaserLib.Extensions;

namespace VincreaserLib.VincreaserCommands
{
    internal class ExcludeCommand : IExcludeCommand
    {
        public string Name => "-exclude";

        private string[] _itemsToExclude;

        public void Parse(string command)
        {
            var excludeItems = command.SubStringBetween('[', ']');
            _itemsToExclude = excludeItems.Split(',');
        }

        public string[] GetExclude()
        {
            return _itemsToExclude;
        }
    }
}
