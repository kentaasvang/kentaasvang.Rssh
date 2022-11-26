namespace kentaasvang.Rssh.Repositories;

public class RepositoryResult<T> where T : class
{
  public bool Succeeded { get; set; } = false;
  public T? Value { get; set; }
  public string ErrorMessage { get; set; } = string.Empty;
}