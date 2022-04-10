using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using Kent.Cli.Rssh.Interfaces;

namespace Kent.Cli.Rssh.Commands;

internal class AddCommand : ICommandInstaller
{
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
            if (group is not null)
            {
                Console.WriteLine($"value of name: {name}");
                Console.WriteLine($"value of group: {group}");
            }
            else
            {
                Console.WriteLine($"value of name: {name}");
            }
        }, nameArg, groupName);

        return command;
    }
}

