using System;
using System.CommandLine;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Commands;

public class ListCommandWrapper : ICommandWrapper
{
    private readonly IListHandler _handler;

    public ListCommandWrapper(IListHandler handler)
    {
        _handler = handler;
    }
    
    public Command UnWrap()
    {
        Command command = new("list");
        command.AddAlias("l");
        command.Description = "Show connections";
        command.SetHandler(_handler.ListAllConnections);
        return command;
    }
}

