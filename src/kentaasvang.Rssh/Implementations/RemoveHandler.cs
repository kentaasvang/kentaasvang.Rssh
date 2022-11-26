using System;
using kentaasvang.Rssh.Interfaces;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations;

public class RemoveHandler : IRemoveHandler
{
    private readonly IConnectionDetailRepository _repo;

    public RemoveHandler(IConnectionDetailRepository repo)
    {
       _repo = repo; 
    }

    public void RemoveConnection(string name)
    {
        var result = _repo.Delete(name);

        if (result.Succeeded)
            Console.WriteLine($"Successfully removed connection: {name}");
        else
            Console.WriteLine($"Failed to remove connection: {name} with error: {result.ErrorMessage}");
    }
}