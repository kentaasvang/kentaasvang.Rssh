using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh;

internal static class DependencyInjectionExtensions
{
    internal static void ConfigureCommands(this RootCommand rootCommand)
    {
        IEnumerable<ICommandInstaller?> commands = GetCommands();

        foreach (var command in commands)
        {
            if (command is null) continue;
            rootCommand.Add(command.LoadCommand());
        }
    }

    private static IEnumerable<ICommandInstaller?> GetCommands()
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
