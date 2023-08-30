using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Interfaces.Commands;

namespace kentaasvang.Rssh.Implementations.Commands;

public class ListCommandWrapper : ICommandWrapper
{
    private readonly ListHandler _handler;

    public ListCommandWrapper(ListHandler handler)
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

