using System;
using System.CommandLine;
using System.Linq;
using kentaasvang.Rssh.Models;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Commands;

internal class RemoveCommand : ICommandInstaller
{
    private readonly RsshDbContext _database = new();
    
    public Command LoadCommand()
    {
        Command command = new("remove");
        command.AddAlias("r");
        command.Description = "Remove connection from database";
        
        Argument nameArg = new Argument<string>("name", "name of the connection");
        command.AddArgument(nameArg);

        command.SetHandler((string name) =>
        {

        }, nameArg);

        return command;
    }
}

