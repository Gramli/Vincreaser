using System;
using VincreaserLib;
using Autofac;
using System.Linq;

namespace VincreaserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var endingCommands = new[] { "close", "end", "c" };
                var container = new VincreaserLibContainer();

                var vincreaserContainer = container.Build();
                using var scope = vincreaserContainer.BeginLifetimeScope();
                var vincreaser = scope.Resolve<IVincreaser>();

                if (args is null || !args.Any())
                {
                    while (true)
                    {
                        var line = Console.ReadLine();
                        if (endingCommands.Any(end => end == line))
                        {
                            return;
                        }
                        vincreaser.Run(new[] { line });

                    }
                }

                vincreaser.Run(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
