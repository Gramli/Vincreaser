using System;
using System.Collections.Generic;
using VincreaserLib.Exceptions;
using VincreaserLib.VincreaserCommands;

namespace VincreaserLib
{
    internal class VincreaserCommandsManager : IVincreaserCommandsManager
    {
        private Dictionary<string, Func<IVincreaserCommand>> _commandsMap;

        public VincreaserCommandsManager(
            Func<IExcludeCommand> excludeCommand,
            Func<IPathCommand> pathCommand,
            Func<ITypeCommand> typeCommand,
            Func<IIncreaseActionCommand> increaseCommand,
            Func<ISetActionCommand> setCommand)
        {
            InicializeCommandsMap(excludeCommand, pathCommand, typeCommand, increaseCommand, setCommand);
        }

        private void InicializeCommandsMap(
            Func<IExcludeCommand> excludeCommand,
            Func<IPathCommand> pathCommand,
            Func<ITypeCommand> typeCommand,
            Func<IIncreaseActionCommand> increaseCommand,
            Func<ISetActionCommand> setCommand)
        {
            _commandsMap = new Dictionary<string, Func<IVincreaserCommand>>
            {
                { "-exclude", excludeCommand },
                { "-path", pathCommand },
                { "-type", typeCommand },
                { "-increase", increaseCommand },
                { "-set", setCommand }
            };
        }

        public IVincreaserCommand GetCommand(string args)
        {
            var indexOfFirstSpace = args.IndexOf(" ");
            var name = args.Substring(0, indexOfFirstSpace);
            var commandArgs = args.Substring(indexOfFirstSpace, args.Length);
            var commandInitFunc = _commandsMap[name] ?? throw new UnknownCommand($"Uknown command name {name}.");
            var vincreaserCommand = commandInitFunc();
            vincreaserCommand.Parse(commandArgs);
            return vincreaserCommand;
        }
    }
}
