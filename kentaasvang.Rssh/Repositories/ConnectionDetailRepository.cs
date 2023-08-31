using System.Collections.Generic;
using System.Linq;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Entities;

namespace kentaasvang.Rssh.Repositories;

public class ConnectionDetailRepository
{
  private readonly RsshDbContext _dbContext;

  public ConnectionDetailRepository(RsshDbContext dbContext)
  {
    _dbContext = dbContext; 
  }

  public Result<string> Delete(string name)
  {
    var entity = _dbContext.ConnectionDetails.FirstOrDefault(entity => entity.Name == name);
    if (entity is null)
      return new Result<string>
      {
        Succeeded = false,
        ErrorMessage = $"Connection with username: '{name}' was not found"
      };

    _dbContext.ConnectionDetails.Remove(entity);
    _dbContext.SaveChanges();

    return new Result<string>
    {
      Succeeded = true,
    };
  }

  public Result<List<string>> GetAllUserNames()
  {
    var entities = _dbContext.ConnectionDetails.Select(cd => cd.Name).ToList();

    return new Result<List<string>>
    {
      Succeeded = true,
      Value = entities
    };
  }

  public Result<string> Insert(ConnectionDetailEntity entity)
  {
    var entry = _dbContext.ConnectionDetails.Add(entity);
    _dbContext.SaveChanges();

    return new Result<string>
    {
      Succeeded = true,
      Value = entry.Entity.Name
    };
  }
}