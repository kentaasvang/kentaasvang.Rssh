namespace kentaasvang.Rssh.Repositories;

using kentaasvang.Rssh.Entities;
using System.Collections.Generic;

public interface IConnectionDetailRepository
{
  public Result<string> Insert(ConnectionDetailEntity entity);
  public Result<List<string>> GetAllUserNames();
  public Result<string> Delete(string name);
}