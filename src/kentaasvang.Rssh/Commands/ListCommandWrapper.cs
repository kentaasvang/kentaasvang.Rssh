using System;
using System.CommandLine;
using System.Linq;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Models;

namespace kentaasvang.Rssh.Commands;

public class ListCommandWrapper : ICommandWrapper
{
    private readonly DatabaseContext _database = new DatabaseContext();
    
    public Command UnWrap()
    {
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
                output += $"Connection displayName: {connection.Name}\n";
                output += $"Connection ip: {connection.Ip}\n";
                output += $"Connection password: {connection.Password}";
                
                Console.WriteLine(output); 
            }
        });

        return command;
    }
}