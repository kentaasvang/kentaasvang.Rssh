using System;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Handlers;

public class ListHandler 
{
    private readonly ConnectionDetailRepository _repo;
    public ListHandler(ConnectionDetailRepository repo)
    {
        _repo = repo;
    }

    public void ListAllConnections()
    {
        var result = _repo.GetAllUserNames();

        if (result.Value is null)
            Console.WriteLine("Your connection store is empty.");
        else
            foreach (var connection in result.Value) Console.WriteLine(connection); 
    }
}