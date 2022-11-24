
namespace kentaasvang.Rssh;

using System.CommandLine;
using System.Threading.Tasks;
using kentaasvang.Rssh.Extensions;

internal class Program
{
    internal static async Task<int> Main(string[] args)
    {
        
        RootCommand rootCommand = new()
        {
            Description = "store ssh credentials for clients",
            Name = "rssh"
        };

        rootCommand.ConfigureCommands();
        
        await rootCommand.InvokeAsync(args);

        return 0;
    }

}

