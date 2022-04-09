using System.CommandLine;
using Kent.Cli.Rssh.Extensions;

namespace Kent.Cli.Rssh;

internal class Program
{
    internal static async Task<int> Main(string[] args)
    {
        RootCommand rootCommand = new();

        // API 
        // Usage
        // rssh <server>
        // rssh <group> <server>

        // adding new groups or servers
        // rssh add <server> (prompts username and password and IP) 
        // rssh add <group> <server> (prompts username and password and IP) 

        // list out groups and servers
        //  >>> rssh list
        //  Groups:
        //      Ebs
        //          stage
        //          develop
        //          prod
        //      Home
        //          main
        //          raspberry  

        // remove groups or single server
        // rssh remove <group> -> removes group totally with all servers belonging to that group
        // rssh remove <group> <server> -> removes only this server 
        // rssh remove <server> -> removes only this server

        // TODO: extract configuration
        rootCommand.Description = "store ssh credentials for clients";
        rootCommand.Name = "rssh";

        rootCommand.ConfigureCommands();

        await rootCommand.InvokeAsync(args);

        return 0;
    }

}

