using System;
using System.Collections.Generic;
using kentaasvang.Rssh.Models;

namespace kentaasvang.Rssh.Repositories;

public class ConnectionDetailRepository : IConnectionDetailRepository
{
  public RepositoryResult<ConnectionDetailEntity> Delete(string name)
  {
    throw new NotImplementedException();
  }

  public RepositoryResult<List<ConnectionDetailEntity>> GetAll()
  {
    throw new NotImplementedException();
  }

  public RepositoryResult<ConnectionDetailEntity> Insert(ConnectionDetailEntity entity)
  {
    throw new NotImplementedException();
  }
}

public interface IConnectionDetailRepository
{
  public RepositoryResult<ConnectionDetailEntity> Insert(ConnectionDetailEntity entity);
  public RepositoryResult<List<ConnectionDetailEntity>> GetAll();
  public RepositoryResult<ConnectionDetailEntity> Delete(string name);
}

public class RepositoryResult<T> where T : class
{
  public bool Succeeded { get; set; } = false;
  public T? Value { get; set; }
  public string? ErrorMessage { get; set; }
}