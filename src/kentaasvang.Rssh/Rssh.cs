using System.CommandLine;
using System.Threading.Tasks;

namespace kentaasvang.Rssh;

public class Rssh
{
  public async Task Run(string[] args)
  {
    RootCommand rootCommand = new()
    {
        Description = "store ssh credentials for clients",
        Name = "rssh"
    };

    rootCommand.ConfigureCommands();
    
    await rootCommand.InvokeAsync(args);
  }
}