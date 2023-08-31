using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;

namespace kentaasvang.Rssh.Implementations.Commands;

public class RemoveCommand 
{
  private readonly RemoveHandler _handler;

  public RemoveCommand(RemoveHandler handler)
  {
    _handler = handler;
  } 

  public Command Create()
  {
    Command command = new("remove");
    command.AddAlias("r");
    command.Description = "Remove connection from database";

    Argument name = new Argument<string>("name", "name of the connection");
    command.AddArgument(name);

    command.SetHandler<string>(_handler.RemoveConnection, name);

    return command;
  }
}

