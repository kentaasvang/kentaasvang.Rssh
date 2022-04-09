using System.CommandLine;
using Kent.Cli.Rssh.Interfaces;

namespace Kent.Cli.Rssh.Commands;

internal class AddCommand : ICommandInstaller
{
    public Command Instantiate()
    {
        Command command = new("add");
        // TODO extract configuration
        command.AddAlias("a");
        command.Description = "save new login";

        return command;
    }
}

