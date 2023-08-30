using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Interfaces.Commands;

namespace kentaasvang.Rssh.Implementations.Commands;

public class RemoveCommandWrapper : ICommandWrapper
{
  private readonly RemoveHandler _handler;

  public RemoveCommandWrapper(RemoveHandler handler)
  {
    _handler = handler;
  } 

  public Command UnWrap()
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

