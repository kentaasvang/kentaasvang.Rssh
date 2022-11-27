using System;
using System.Diagnostics;
using System.IO;
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

  public void Connect(string username)
  {
    string returnvalue = string.Empty;

    var psi = new ProcessStartInfo();
    psi.FileName = "/usr/bin/ssh";
    psi.Arguments = "root@asvang.no";

    psi.RedirectStandardOutput = false;
    psi.RedirectStandardError = false;
    psi.RedirectStandardInput = false;

    psi.UseShellExecute = true;
    psi.CreateNoWindow = true;

    Process.Start(psi)?.WaitForExit();
  }
}