using System.Diagnostics;
using System.Threading.Tasks;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Handlers;

public class ConnectionHandler 
{
  private readonly ConnectionDetailRepository _repo;

  public ConnectionHandler(ConnectionDetailRepository repo)
  {
    _repo = repo;
  }

  public async Task Connect(string username)
  {
    var startInfo = new ProcessStartInfo()
    {
      FileName = "/usr/bin/ssh",
      Arguments = "kent@asvang.no",
      UseShellExecute = true,
    };

    var proc = Process.Start(startInfo);

    // var output = await proc?.StandardOutput.ReadToEndAsync()!;

    await proc?.WaitForExitAsync()!;

    // Console.WriteLine(output);
  }
}