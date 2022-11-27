using System.CommandLine;
using kentaasvang.Rssh.Interfaces.Commands;
using kentaasvang.Rssh.Interfaces.Handlers;

namespace kentaasvang.Rssh.Implementations.Commands;

public class AddCommandWrapper : ICommandWrapper
{
    private IAddHandler _handler;

    public AddCommandWrapper(IAddHandler handler)
    {
       _handler = handler; 
    }

    public Command UnWrap()
    {
        Command command = new("add");
        command.AddAlias("a");
        command.Description = "save new connection";
        
        Argument name = new Argument<string>(nameof(name), "name of the connection");
        command.AddArgument(name);

        command.SetHandler<string>(_handler.InsertNewConnection, name);

        return command;
    }
}