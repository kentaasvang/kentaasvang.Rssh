using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;

namespace kentaasvang.Rssh.Implementations.Commands;

public class AddCommand 
{
    private readonly AddHandler _handler;

    public AddCommand(AddHandler handler)
    {
       _handler = handler; 
    }

    public Command Create()
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