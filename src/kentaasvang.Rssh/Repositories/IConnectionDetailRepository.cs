namespace kentaasvang.Rssh.Repositories;

using kentaasvang.Rssh.Models;
using System.Collections.Generic;

public interface IConnectionDetailRepository
{
  public RepositoryResult<ConnectionDetailEntity> Insert(ConnectionDetailEntity entity);
  public RepositoryResult<List<ConnectionDetailEntity>> GetAll();
  public RepositoryResult<ConnectionDetailEntity> Delete(string name);
}