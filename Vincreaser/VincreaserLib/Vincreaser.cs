using System;
using System.Collections.Generic;
using System.Linq;
using VincreaserLib.VincreaserCommands;

namespace VincreaserLib
{
    public class Vincreaser : IVincreaser
    {
        private readonly IVincreaserCommandsManager _commandsManager;

        public Vincreaser()
        {
        }


        //COmmands dictionary with priorit - maybe class with interface
        //add logic for csproj to init all in folder
        public void Run(string[] args)
        {
            var actionCommands = new List<IVincreaserCommand>();

            var commands = args[0].Split("-");
            foreach (var command in commands)
            {
                var vCommand = _commandsManager.GetCommand(command);
                actionCommands.Add(vCommand);
            }

            //get path
            var pathCommand = (IPathCommand)actionCommands.SingleOrDefault(i => i is IPathCommand) ?? throw new Exception("Can't find -path argument");
            var path = pathCommand.GetPath();

            var typeCommand = (ITypeCommand)actionCommands.SingleOrDefault(i => i is ITypeCommand) ?? throw new Exception("Can't find -type argument");
            var versionFile = typeCommand.GetVersionFile();

            var excludeCommand = (IExcludeCommand) actionCommands.FirstOrDefault(i => i is IExcludeCommand);
            var exclude = excludeCommand?.GetExclude();

            var actionCommand = (ActionCommand)actionCommands.SingleOrDefault(i => i is ActionCommand) ?? throw new Exception("Can't find -increase or -set argument");

            actionCommand.Run(versionFile,path,exclude);
        }
    }
}
