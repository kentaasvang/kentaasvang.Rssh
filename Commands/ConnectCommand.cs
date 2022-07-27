using System;
using System.CommandLine;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Commands;

internal class ConnectCommand : ICommandInstaller
{
    public Command LoadCommand()
    {
        Command command = new("connect");

        // TODO extract configuration
        command.AddAlias("con");
        command.Description = "Connect to a server";

        command.SetHandler(() => Console.WriteLine("hello from connect!"));

        return command;
    }
}

