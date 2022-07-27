using System.CommandLine;

namespace kentaasvang.Rssh.Interfaces;

internal interface ICommandInstaller
{
    Command LoadCommand();
}
