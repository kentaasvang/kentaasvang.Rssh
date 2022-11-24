using System.CommandLine;

namespace kentaasvang.Rssh.Commands;

public interface ICommandWrapper
{
  public Command UnWrap();
}