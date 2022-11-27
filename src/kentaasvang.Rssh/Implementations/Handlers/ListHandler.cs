using System;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Handlers;

public class ListHandler : IListHandler
{
    private readonly IConnectionDetailRepository _repo;
    public ListHandler(IConnectionDetailRepository repo)
    {
        _repo = repo;
    }

    public void ListAllConnections()
    {
        var result = _repo.GetAllUserNames();

        if (result.Value is null)
            Console.WriteLine("Your connection store is empy.");
        else
            foreach (var connection in result.Value) Console.WriteLine(connection); 
    }
}