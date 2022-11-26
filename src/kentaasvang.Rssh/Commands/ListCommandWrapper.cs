using System;
using System.CommandLine;
using System.Linq;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Models;

namespace kentaasvang.Rssh.Commands;

public class ListCommandWrapper : ICommandWrapper
{
    private readonly IListHandler _handler;

    public ListCommandWrapper(IListHandler handler)
    {
        _handler = handler;
    }
    
    public Command UnWrap()
    {
        Command command = new("list");
        command.AddAlias("l");
        command.Description = "Show connections";
        command.SetHandler(_handler.ListAllConnections);
        return command;
    }
}

public class ListHandler : IListHandler
{
    private RsshDbContext _dbContext;

    public ListHandler(RsshDbContext dbContext)
    {
       _dbContext = dbContext; 
    }

    public void ListAllConnections()
    {
        ConnectionDetailEntity[] connections = _dbContext.ConnectionDetails.ToArray();

        foreach (var connection in connections)
            Console.WriteLine(connection.Name); 
    }
}

public interface IListHandler
{
    public void ListAllConnections();
}