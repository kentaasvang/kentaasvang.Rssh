using System;
using System.CommandLine;
using System.Linq;
using Kent.Cli.Rssh.Data;
using Kent.Cli.Rssh.Interfaces;
using Kent.Cli.Rssh.Models;

namespace Kent.Cli.Rssh.Commands;

public class ListCommand : ICommandInstaller
{
    private readonly DatabaseContext _database = new DatabaseContext();
    
    public Command LoadCommand()
    {
        // list out groups and servers
        //  >>> rssh list
        //  Groups:
        //      Ebs
        //          stage
        //          develop
        //          prod
        //      Home
        //          main
        //          raspberry  
        Command command = new("list");
        command.AddAlias("l");
        command.Description = "Show connections";

        command.SetHandler(() =>
        {
            ConnectionDetail[] connections = _database.ConnectionDetails.ToArray();

            foreach (var connection in connections)
            {
                // TODO: for display purposes, should only show displayname
                string output = $"Connection username: {connection.Username}\n";
                output += $"Connection displayName: {connection.ConnectionName}\n";
                output += $"Connection ip: {connection.Ip}\n";
                output += $"Connection password: {connection.Password}";
                
                Console.WriteLine(output); 
            }
        });

        return command;
    }
}