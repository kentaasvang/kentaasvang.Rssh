using System.CommandLine;

namespace kentaasvang.Rssh.Interfaces.Commands;

public interface ICommandWrapper
{
  public Command UnWrap();
}