using System;
using System.CommandLine;
using kentaasvang.Rssh.Interfaces.Commands;

namespace kentaasvang.Rssh.Implementations.Commands;

internal class ConnectCommand : ICommandWrapper

{
    public Command UnWrap()
    {
        Command command = new("connect");

        command.AddAlias("con");
        command.Description = "Connect to a server";

        command.SetHandler(() => Console.WriteLine("hello from connect!"));

        return command;
    }
}

