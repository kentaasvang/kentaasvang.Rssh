using System;
using System.CommandLine;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Models;

namespace kentaasvang.Rssh.Commands;

internal class Add : ICommandInstaller
{
    public Command LoadCommand()
    {
        Command command = new("add");
        command.AddAlias("a");
        command.Description = "save new connection";
        
        Option groupName = new Option<string>("--group")
        {
            IsHidden = false,
            ArgumentHelpName = "the group name",
            AllowMultipleArgumentsPerToken = false,
            IsRequired = false,
            Arity = default,
        };
        
        Argument name = new Argument<string>("name", "name of the connection");
        command.AddArgument(name);

        var inputProvider = new InputProvider();
        var handler = new AddHandler(new DatabaseContext(), inputProvider);

        command.SetHandler<string>(handler.Handler, name);

        return command;
    }
}

public interface IAddHandler
{
    public void Handler(string connectionName);
}

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

public interface IInputProvider
{
    public string GetInput();
}

public class InputProvider : IInputProvider
{
  public string GetInput()
  {
    return Console.ReadLine() ?? throw new NullReferenceException("Input can't be empty");
  }
}
