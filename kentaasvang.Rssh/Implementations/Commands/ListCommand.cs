using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;

namespace kentaasvang.Rssh.Implementations.Commands;

public class ListCommand 
{
    private readonly ListHandler _handler;

    public ListCommand(ListHandler handler)
    {
        _handler = handler;
    }
    
    public Command Create()
    {
        Command command = new("list");
        command.AddAlias("l");
        command.Description = "Show connections";
        command.SetHandler(_handler.ListAllConnections);
        return command;
    }
}

