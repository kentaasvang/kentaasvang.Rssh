using System.CommandLine;
using System.Threading.Tasks;
using kentaasvang.Rssh.Implementations.Commands;

namespace kentaasvang.Rssh;

public class Rssh
{
  private readonly RootCommand _rootCommand;

  public Rssh(
    AddCommand addCommand, 
    ListCommand listCommand,
    RemoveCommand removeCommand,
    ConnectCommand connectCommand
    )
  {
    _rootCommand = new RootCommand
    { 
      Description = "store ssh credentials for clients", Name = "rssh" 
    };

    _rootCommand.Add(addCommand.Create());
    _rootCommand.Add(listCommand.Create());
    _rootCommand.Add(removeCommand.Create());
    _rootCommand.Add(connectCommand.Create());
  }

  public async Task Run(string[] args)
  {
    await _rootCommand.InvokeAsync(args);
  }
}