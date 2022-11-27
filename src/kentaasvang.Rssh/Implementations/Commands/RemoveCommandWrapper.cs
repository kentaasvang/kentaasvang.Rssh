using System.CommandLine;
using kentaasvang.Rssh.Interfaces.Commands;
using kentaasvang.Rssh.Interfaces.Handlers;

namespace kentaasvang.Rssh.Implementations.Commands;

public class RemoveCommandWrapper : ICommandWrapper
{
  private readonly IRemoveHandler _handler;

  public RemoveCommandWrapper(IRemoveHandler handler)
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

