using System;
using System.CommandLine;
using System.Linq;
using Kent.Cli.Rssh.Interfaces;

namespace Kent.Cli.Rssh.Extensions;

internal static class Extensions
{
    internal static void ConfigureCommands(this RootCommand rootCommand)
    {
        ICommandInstaller?[] commands = GetCommands();

        foreach (var command in commands)
        {
            if (command is null) continue;
            rootCommand.Add(command.LoadCommand());
        }
    }

    private static ICommandInstaller?[] GetCommands()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(asm => asm.GetTypes())
            .Where(
                type => typeof(ICommandInstaller).IsAssignableFrom(type)
                && !type.IsInterface
                && !type.IsAbstract
            )
            .Select(type => Activator.CreateInstance(type) as ICommandInstaller)
            .ToArray();
    }
}
