using System;
using System.Collections.Generic;
using System.Linq;
using VincreaserLib.Exceptions;
using VincreaserLib.VincreaserCommands;

namespace VincreaserLib
{
    public class Vincreaser : IVincreaser
    {
        private readonly IVincreaserCommandsManager _commandsManager;

        public Vincreaser(IVincreaserCommandsManager commandsManager)
        {
            _commandsManager = commandsManager;
        }

        public void Run(params string[] args)
        {
            if (!args.Any() || args is null)
            {
                throw new ArgumentNullException("Run arguments are empty or null");
            }

            foreach (var arg in args)
            {
                var actionCommands = new List<IVincreaserCommand>();

                var commands = arg.Split("-");
                foreach (var command in commands)
                {
                    var vCommand = _commandsManager.GetCommand(command);
                    actionCommands.Add(vCommand);
                }

                var pathCommand = (IPathCommand)actionCommands.SingleOrDefault(i => i is IPathCommand) ?? throw new UnknownCommand("Can't find mandatory command -path.");
                var path = pathCommand.GetPath();

                var typeCommand = (ITypeCommand)actionCommands.SingleOrDefault(i => i is ITypeCommand) ?? throw new UnknownCommand("Can't find mandatory command -type");
                var versionFile = typeCommand.GetVersionFile();

                var excludeCommand = (IExcludeCommand)actionCommands.FirstOrDefault(i => i is IExcludeCommand);
                var exclude = excludeCommand?.GetExclude();

                var actionCommand = (IActionCommand)actionCommands.SingleOrDefault(i => i is IActionCommand) ?? throw new UnknownCommand("Can't find mandatory command -increase or -set");

                actionCommand.Run(versionFile, path, exclude);
            }
        }
    }
}
