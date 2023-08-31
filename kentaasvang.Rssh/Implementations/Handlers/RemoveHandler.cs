using System;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Handlers;

public class RemoveHandler 
{
    private readonly ConnectionDetailRepository _repo;

    public RemoveHandler(ConnectionDetailRepository repo)
    {
       _repo = repo; 
    }

    public void RemoveConnection(string name)
    {
        var result = _repo.Delete(name);

        Console.WriteLine(result.Succeeded
            ? $"Successfully removed connection: {name}"
            : $"Failed to remove connection: {name} with error: {result.ErrorMessage}");
    }
}