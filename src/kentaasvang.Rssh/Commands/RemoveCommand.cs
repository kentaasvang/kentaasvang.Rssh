using System.CommandLine;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Commands;

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

