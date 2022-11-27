using System;
using System.CommandLine;

namespace kentaasvang.Rssh.Commands;

internal class ConnectCommand : ICommandWrapper

{
    public Command UnWrap()
    {
        Command command = new("connect");

        // TODO extract configuration
        command.AddAlias("con");
        command.Description = "Connect to a server";

        command.SetHandler(() => Console.WriteLine("hello from connect!"));

        return command;
    }
}

