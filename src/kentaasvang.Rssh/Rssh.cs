using System.CommandLine;
using System.Threading.Tasks;
using kentaasvang.Rssh.Implementations.Commands;
using kentaasvang.Rssh.Interfaces.Commands;

namespace kentaasvang.Rssh;

public class Rssh
{
  private readonly RootCommand _rootCommand;

  public Rssh(
    AddCommandWrapper addCommandWrapper, 
    ListCommandWrapper listCommandWrapper,
    RemoveCommandWrapper removeCommandWrapper,
    ConnectCommandWrapper connectCommandWrapper
    )
  {
    _rootCommand = new RootCommand
    { 
      Description = "store ssh credentials for clients", Name = "rssh" 
    };

    AddCommand(addCommandWrapper);
    AddCommand(listCommandWrapper);
    AddCommand(removeCommandWrapper);
    AddCommand(connectCommandWrapper);
  }

  public async Task Run(string[] args)
  {
    await _rootCommand.InvokeAsync(args);
  }

  private void AddCommand(ICommandWrapper commandWrapper)
    => _rootCommand.Add(commandWrapper.UnWrap());

}