using System;
using System.Linq;
using VincreaserLib.Exceptions;
using VincreaserLib.Extensions;
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
                throw new UnknownCommand("Run arguments are empty or null");
            }

            foreach (var arg in args)
            {
                var commands = arg.SplitAndRemoveSpaces('-');

                var actionCommands = commands.Select(command => _commandsManager.GetCommand(command)).ToList();

                var typeCommand = (ITypeCommand)actionCommands.SingleOrDefault(i => i is ITypeCommand) ?? throw new UnknownCommand("Can't find mandatory command -type");
                var versionFile = typeCommand.GetVersionFile();

                var pathCommand = (IPathCommand)actionCommands.SingleOrDefault(i => i is IPathCommand) ?? throw new UnknownCommand("Can't find mandatory command -path.");
                var paths = pathCommand.GetPaths(versionFile);

                var excludeCommand = (IExcludeCommand)actionCommands.FirstOrDefault(i => i is IExcludeCommand);
                var exclude = excludeCommand?.GetExclude();

                var actionCommand = (IActionCommand)actionCommands.SingleOrDefault(i => i is IActionCommand) ?? throw new UnknownCommand("Can't find mandatory command -increase or -set");

                foreach (var path in paths)
                {
                    if (exclude?.Contains(path) ?? true)
                    {
                        actionCommand.Run(versionFile, path);
                    }
                }
            }
        }
    }
}
