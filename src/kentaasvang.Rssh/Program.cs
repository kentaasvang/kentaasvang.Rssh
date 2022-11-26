﻿namespace kentaasvang.Rssh;

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

        services.AddHandlers();
        services.AddRepos();
        services.AddDatabase();
        services.AddCommands();

        services.AddTransient<IInputProvider, InputProvider>();
        services.AddTransient<Rssh>();

        var options = new ServiceProviderOptions();
        options.ValidateOnBuild = true;
        options.ValidateScopes = true;

        var serviceProvider = services.BuildServiceProvider(options);

        var app = serviceProvider.GetRequiredService<Rssh>();

        await app.Run(args);
    }
}

