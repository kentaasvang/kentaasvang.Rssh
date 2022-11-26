using System;
using System.CommandLine;
using System.Linq;
using kentaasvang.Rssh.Models;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces;

namespace kentaasvang.Rssh.Commands;

internal class RemoveCommand : ICommandInstaller
{
    private readonly RsshDbContext _database = new();
    
    // remove groups or single server
    // rssh remove <group> -> removes group totally with all servers belonging to that group
    // rssh remove <group> <server> -> removes only this server 
    // rssh remove <server> -> removes only this server
    public Command LoadCommand()
    {
        Command command = new("remove");
        command.AddAlias("r");
        command.Description = "Remove connection from database";
        
        Argument nameArg = new Argument<string>("name", "name of the connection");
        command.AddArgument(nameArg);

        command.SetHandler((string name) =>
        {
             var cd = _database
                 .ConnectionDetails
                 .First(cd => cd.Name == name);
            
             _database.Remove(cd);
             Console.WriteLine($"Deleting cd with name: {name}");
             _database.SaveChanges();

        }, nameArg);

        return command;
    }
}