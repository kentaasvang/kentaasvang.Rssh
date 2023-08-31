using System.CommandLine;
using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Commands;

public class ConnectCommand 
{
  private readonly ConnectionDetailRepository _repo;
  private readonly ConnectionHandler _handler;

  public ConnectCommand(ConnectionDetailRepository repo, ConnectionHandler handler)
  {
    _repo = repo;
    _handler = handler;
  }

  public Command Create()
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

