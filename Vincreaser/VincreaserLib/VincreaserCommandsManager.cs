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
            Func<IGetActionCommand> getCommand,
            Func<ISetActionCommand> setCommand,
            Func<IInitActionCommand> initCommand)
        {
            InicializeCommandsMap(excludeCommand, pathCommand, typeCommand, increaseCommand, getCommand, setCommand, initCommand);
        }

        private void InicializeCommandsMap(
            Func<IExcludeCommand> excludeCommand,
            Func<IPathCommand> pathCommand,
            Func<ITypeCommand> typeCommand,
            Func<IIncreaseActionCommand> increaseCommand,
            Func<IGetActionCommand> getCommand,
            Func<ISetActionCommand> setCommand,
            Func<IInitActionCommand> initCommand)
        {
            _commandsMap = new Dictionary<string, Func<IVincreaserCommand>>
            {
                { "exclude", excludeCommand },
                { "path", pathCommand },
                { "type", typeCommand },
                { "increase", increaseCommand },
                { "set", setCommand },
                { "get", getCommand },
                { "init",  initCommand}
            };
        }

        public IVincreaserCommand GetCommand(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                throw new UnknownCommand($"Can't retrieve command from null args.");
            }

            var indexOfFirstSpace = args.IndexOf(" ", StringComparison.Ordinal);

            if(indexOfFirstSpace == -1)
            {
                throw new UnknownCommand($"Can't space between args.");
            }

            var name = args.Substring(0, indexOfFirstSpace);
            var commandArgs = args.Substring(indexOfFirstSpace, args.Length - indexOfFirstSpace);
            var commandInitFunc = _commandsMap[name] ?? throw new UnknownCommand($"Uknown command name {name}.");
            var vincreaserCommand = commandInitFunc();
            vincreaserCommand.Parse(commandArgs);
            return vincreaserCommand;
        }
    }
}
