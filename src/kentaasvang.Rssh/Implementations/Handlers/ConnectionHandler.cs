using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Repositories;

namespace kentaasvang.Rssh.Implementations.Handlers;

public class ConnectionHandler : IConnectionHandler
{
  private readonly IConnectionDetailRepository _repo;

  public ConnectionHandler(IConnectionDetailRepository repo)
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