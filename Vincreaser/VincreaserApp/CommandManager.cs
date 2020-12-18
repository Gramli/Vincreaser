using Autofac;
using System;
using System.Collections.Generic;
using VincreaserApp.Extensions;
using VincreaserLib;

namespace VincreaserApp
{
    internal class CommandManager
    {
        private Dictionary<string, Action> commands = new Dictionary<string, Action>()
        {
            { "-examples", () => { BrowserExtensions.OpenBrowserByPlatform("https://github.com/Gramli/Vincreaser"); }  },
            { "-help", () => {
                Console.WriteLine(@"
-type (.csproj, assemblyInfo.cs, version.go)
-increase
    major (example: -increase major)
    minor (example: -increase minor)
    build (example: -increase build)
    revision (example: -increase revision)
-set version (example: -set 1.1.2.3)
-get
-path directory or file (example: -path C:\git\MySolution\ -increase patch 1)
-exclude [projectname, secondProjectName, ...] (example: -path C:\git\MySolution\ -increase patch 1 -exclude[MySecondProject])

-help Show help information
-examples show examples in Github readme
-close, -end, -c close program by command");
            }  },
        };

        private readonly IVincreaser vincreaser;

        public CommandManager()
        {
            var container = new VincreaserLibContainer();
            var vincreaserContainer = container.Build();
            var scope = vincreaserContainer.BeginLifetimeScope();
            vincreaser = scope.Resolve<IVincreaser>();
        }


        public string[] Run(string arguments)
        {
            if (commands.TryGetValue(arguments, out var action))
            {
                action();
                return new string[] { };
            }

            return vincreaser.Run(new[] { arguments });
        }

        public string[] Run(string[] arguments)
        {
            return vincreaser.Run(arguments);
        }

    }
}
