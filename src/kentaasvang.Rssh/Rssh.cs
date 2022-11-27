using System.CommandLine;
using System.Threading.Tasks;
using kentaasvang.Rssh.Commands;
using kentaasvang.Rssh.Implementations;

namespace kentaasvang.Rssh;

public class Rssh
{
  private RootCommand _rootCommand;

  public Rssh(
    AddCommandWrapper addCommandWrapper, 
    ListCommandWrapper listCommandWrapper,
    RemoveCommandWrapper removeCommand
    )
  {
    _rootCommand = new() 
    { 
      Description = "store ssh credentials for clients", Name = "rssh" 
    };

    AddCommand(addCommandWrapper);
    AddCommand(listCommandWrapper);
    AddCommand(removeCommand);
  }

  public async Task Run(string[] args)
  {
    await _rootCommand.InvokeAsync(args);
  }

  private void AddCommand(ICommandWrapper commandWrapper)
    => _rootCommand.Add(commandWrapper.UnWrap());

}