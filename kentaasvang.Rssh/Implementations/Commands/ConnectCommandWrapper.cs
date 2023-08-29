using System.CommandLine;
using kentaasvang.Rssh.Interfaces.Commands;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Commands;

public class ConnectCommandWrapper : ICommandWrapper
{
  private readonly IConnectionDetailRepository _repo;
  private readonly IConnectionHandler _handler;

  public ConnectCommandWrapper(IConnectionDetailRepository repo, IConnectionHandler handler)
  {
    _repo = repo;
    _handler = handler;
  }

  public Command UnWrap()
  {
    Command command = new("connect");

    command.AddAlias("con");
    command.Description = "Connect to a server";

    var username = new Argument<string>("username", "username to connect to server with");
    command.AddArgument(username);

    command.SetHandler<string>(_handler.Connect, username);

    return command;
  }
}

