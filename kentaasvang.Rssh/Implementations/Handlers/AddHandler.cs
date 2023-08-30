namespace kentaasvang.Rssh.Implementations.Handlers;

using System;
using Entities;
using Repositories;
using Interfaces;

public class AddHandler 
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
    var ip = _inputProvider.GetInput(); 

    Console.Write("Enter username to use when connecting: ");
    var username = _inputProvider.GetInput(); 

    Console.Write("Enter password: ");
    var password = _inputProvider.GetInput(); 

    ConnectionDetailEntity connectionDetails = new() 
    {
      Name = name,
      Ip = ip,
      Username = username,
      Password = password 
    };

    var result = _repo.Insert(connectionDetails);

    Console.WriteLine(result.Succeeded
      ? $"Successfully inserted new connection: {result?.Value}"
      : $"Something went wrong: {result?.ErrorMessage}");
  } 
}