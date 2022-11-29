using System.Threading.Tasks;

namespace kentaasvang.Rssh.Interfaces.Handlers;

public interface IConnectionHandler
{
  // public void Connect(string username, string password);
  public Task Connect(string username);
}