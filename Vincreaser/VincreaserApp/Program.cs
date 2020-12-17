using System;
using System.Linq;

namespace VincreaserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandManager = new CommandManager();

            Console.WriteLine("Welcome to Vincreaser.\nWrite -help command to more info or -examples to see examples.");

            var endingCommands = new[] { "-close", "-end", "-c" };

            if (args is null || !args.Any())
            {
                while (true)
                {
                    try
                    {
                        var line = Console.ReadLine();

                        if (endingCommands.Any(end => end == line))
                        {
                            return;
                        }

                        var results = commandManager.Run(line);
                        foreach (var result in results)
                        {
                            Console.WriteLine(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception: {ex.GetType().Name}\nMessage: {ex.Message}");
                    }
                }
            }
        }
    }
}
