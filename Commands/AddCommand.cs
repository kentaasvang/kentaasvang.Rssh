using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using Kent.Cli.Rssh.Data;
using Kent.Cli.Rssh.Interfaces;
using Kent.Cli.Rssh.Models;

namespace Kent.Cli.Rssh.Commands;

internal class AddCommand : ICommandInstaller
{
    internal readonly DatabaseContext _database = new();
    public Command LoadCommand()
    {
        // adding new groups or servers
        // rssh add <server name> (prompts username and password and IP) 
        // rssh add <group> <server> (prompts username and password and IP) 
        
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
        groupName.AddAlias("-g");
        command.AddOption(groupName);
            
        Argument nameArg = new Argument<string>("name", "name of the connection");
        command.AddArgument(nameArg);

        command.SetHandler((string name, string? group) => 
        {
            if (group is null)
            {
                Guid guid = new();
                
                Console.Write("Give ip: ");
                string? ip = Console.ReadLine();
                
                Console.Write("Give username: ");
                string? username = Console.ReadLine();
                
                Console.Write("Give password: ");
                string? password = Console.ReadLine();

                ConnectionDetail cd = new(
                    guid, 
                    name, 
                    ip, 
                    username, 
                    password, 
                    null
                );

                _database.Add(cd);
                _database.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }, nameArg, groupName);

        return command;
    }
}

