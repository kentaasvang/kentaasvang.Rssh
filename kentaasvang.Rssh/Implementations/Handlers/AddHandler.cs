namespace kentaasvang.Rssh.Implementations.Handlers;

using System;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Entities;
using kentaasvang.Rssh.Repositories;
using kentaasvang.Rssh.Interfaces;

public class AddHandler : IAddHandler
{
  private readonly IConnectionDetailRepository _repo;
  private readonly IInputProvider _inputProvider;

  public AddHandler(IConnectionDetailRepository repo, IInputProvider inputProvider)
  {
    _repo = repo;
    _inputProvider = inputProvider;
  }

  public void InsertNewConnection(string name)
  {
    Console.Write("Enter IP-address for connection: ");
    string ip = _inputProvider.GetInput(); 

    Console.Write("Enter username to use when connecting: ");
    string username = _inputProvider.GetInput(); 

    Console.Write("Enter password: ");
    string password = _inputProvider.GetInput(); 

    ConnectionDetailEntity connectionDetails = new() 
    {
      Name = name,
      Ip = ip,
      Username = username,
      Password = password 
    };

    var result = _repo.Insert(connectionDetails);

    if (result.Succeeded)
      Console.WriteLine($"Successfully inserted new connection: {result?.Value}");
    else
      Console.WriteLine($"Something wen't wrong: {result?.ErrorMessage}");
  } 
}