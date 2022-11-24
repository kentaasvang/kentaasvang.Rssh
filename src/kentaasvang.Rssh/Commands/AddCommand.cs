using System.CommandLine;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Commands;

internal class AddCommand
{
    private IAddHandler _handler;

    public AddCommand(IAddHandler handler)
    {
       _handler = handler; 
    }

    public Command LoadCommand()
    {
        Command command = new("add");
        command.AddAlias("a");
        command.Description = "save new connection";
        
        Option groupName = new Option<string>("--group")
        {
            IsHidden = false,
            ArgumentHelpName = "the group name",
            AllowMultipleArgumentsPerToken = false,
            IsRequired = false,
            Arity = default,
        };
        
        Argument name = new Argument<string>("name", "name of the connection");
        command.AddArgument(name);

        // var inputProvider = new InputProvider();
        // var handler = new AddHandler(new DatabaseContext(), inputProvider);

        command.SetHandler<string>(_handler.Handler, name);

        return command;
    }
}