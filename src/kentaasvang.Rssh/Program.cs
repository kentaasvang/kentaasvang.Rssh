namespace kentaasvang.Rssh;

using System.Threading.Tasks;
using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using kentaasvang.Rssh.Data;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IInputProvider, InputProvider>()
            .AddTransient<IAddHandler, AddHandler>()
            .AddDbContext<DatabaseContext>()
            .AddTransient<Rssh>()
            .BuildServiceProvider();

        var app = serviceProvider.GetRequiredService<Rssh>();
        await app.Run(args);
    }
}

