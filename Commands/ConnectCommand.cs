using System;
using System.CommandLine;
using Kent.Cli.Ebs.Interfaces;

namespace Kent.Cli.Ebs.Commands;

internal class ConnectCommand : ICommandInstaller
{
    public Command Instantiate()
    {
        Command command = new("connect");
        // TODO extract configuration
        command.AddAlias("con");
        command.Description = "Connect to a servers";

        // environment stage|dev|prod|local
        // client server|pi|db

        return command;
    }
}

