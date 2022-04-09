using System.CommandLine;
using Kent.Cli.Rssh.Interfaces;

namespace Kent.Cli.Rssh.Commands;

internal class ConnectCommand : ICommandInstaller
{
    public Command Instantiate()
    {
        Command command = new("connect");

        // TODO extract configuration
        command.AddAlias("con");
        command.Description = "Connect to a server";

        // fingure out how to get input here so that I can run "rssh con myname" and print myname
        command.SetHandler(() => Console.WriteLine("hello from connect!"));

        return command;
    }
}

