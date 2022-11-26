namespace kentaasvang.Rssh;

using System.Threading.Tasks;
using kentaasvang.Rssh.Implementations;
using kentaasvang.Rssh.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Commands;

internal class Program
{
    internal static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        var serviceProvider = services
            .AddTransient<IInputProvider, InputProvider>()
            .AddTransient<IAddHandler, AddHandler>()
            .AddTransient<IListHandler, ListHandler>()
            .AddDbContext<RsshDbContext>()
            .AddTransient<AddCommandWrapper>()
            .AddTransient<ListCommandWrapper>()
            .AddTransient<Rssh>()
            .BuildServiceProvider();

        var app = serviceProvider.GetRequiredService<Rssh>();

        await app.Run(args);
    }
}

