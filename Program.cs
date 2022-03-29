using System.CommandLine;
using Kent.Cli.Rssh.Extensions;

namespace Kent.Cli.Rssh;

internal class Program
{
    internal static async Task<int> Main(string[] args)
    {
        RootCommand rootCommand = new();

        // TODO: extract configuration
        rootCommand.Description = "store ssh credentials for clients";
        rootCommand.Name = "rssh";

        rootCommand.ConfigureCommands();

        await rootCommand.InvokeAsync(args);

        return 0;
    }

}

