using System.CommandLine;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Commands;

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
        
        Argument name = new Argument<string>("name", "name of the connection");
        command.AddArgument(name);

        // var inputProvider = new InputProvider();
        // var handler = new AddHandler(new DatabaseContext(), inputProvider);

        command.SetHandler<string>(_handler.Handler, name);

        return command;
    }
}