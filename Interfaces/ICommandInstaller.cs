using System.CommandLine;

namespace Kent.Cli.Rssh.Interfaces;

internal interface ICommandInstaller
{
    Command Instantiate();
}
