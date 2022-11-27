using System;
using System.Diagnostics;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Handlers;

public class ConnectionHandler : IConnectionHandler
{
  private readonly IConnectionDetailRepository _repo;

  public ConnectionHandler(IConnectionDetailRepository repo)
  {
    _repo = repo;
  }

  // public void Connect(string username, string password)
  // {
  //   Console.WriteLine("heoooooo");
  // }

  public void Connect(string username)
  {
    Console.WriteLine("heoooooo");
  }
}