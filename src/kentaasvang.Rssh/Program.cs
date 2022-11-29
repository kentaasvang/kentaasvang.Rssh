namespace kentaasvang.Rssh;

using System.Threading.Tasks;
using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;

internal static class Program
{
    internal static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddHandlers();
        services.AddRepos();
        services.AddDatabase();
        services.AddCommands();

        services.AddTransient<IInputProvider, InputProvider>();
        services.AddScoped<Rssh>();

        var options = new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            // ValidateScopes = true
        };
        
        var serviceProvider = services.BuildServiceProvider(options);

        var app = serviceProvider.GetRequiredService<Rssh>();

        await app.Run(args);
    }
}

