namespace kentaasvang.Rssh.Implementations;

using System;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Models;

public class AddHandler : IAddHandler
{
    private DatabaseContext _dbContext;
    private IInputProvider _inputProvider;

    public AddHandler(DatabaseContext dbContext, IInputProvider inputProvider)
    {
        _dbContext = dbContext;
        _inputProvider = inputProvider;
  }

  public void Handler(string name)
    {
        Console.Write("Give ip: ");
        string ip = _inputProvider.GetInput(); 
        
        Console.Write("Give username: ");
        string username = _inputProvider.GetInput(); 
        
        Console.Write("Give password: ");
        string password = _inputProvider.GetInput(); 

        ConnectionDetail connectionDetails = new() 
        {
           Name = name,
           Ip = ip,
           Username = username,
           Password = password 
        };

        _dbContext.Add(connectionDetails);
        _dbContext.SaveChanges();
    } 
}