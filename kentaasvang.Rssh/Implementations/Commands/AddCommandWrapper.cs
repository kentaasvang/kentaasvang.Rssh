using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Interfaces.Commands;

namespace kentaasvang.Rssh.Implementations.Commands;

public class AddCommandWrapper : ICommandWrapper
{
    private readonly AddHandler _handler;

    public AddCommandWrapper(AddHandler handler)
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