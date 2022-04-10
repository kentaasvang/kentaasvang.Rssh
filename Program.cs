using System;
using System.CommandLine;
using System.Threading.Tasks;
using Kent.Cli.Rssh.Extensions;

namespace Kent.Cli.Rssh;

internal class Program
{
    internal static async Task<int> Main(string[] args)
    {
        // TODO: extract configuration
        // rssh <group> <server>
        // rssh <server>
        // Usage
        // API 
        RootCommand rootCommand = new()
        {
            Description = "store ssh credentials for clients",
            Name = "rssh"
        };

        rootCommand.ConfigureCommands();
        
        await rootCommand.InvokeAsync(args);

        return 0;
    }

}

