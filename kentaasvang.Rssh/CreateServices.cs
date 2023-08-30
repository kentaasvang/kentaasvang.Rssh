using kentaasvang.Rssh.Implementations.Commands;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace kentaasvang.Rssh;

internal static class CreateServices
{
  internal static void AddHandlers(this IServiceCollection services)
  {
    services.AddTransient<AddHandler>();
    services.AddTransient<ListHandler>();
    services.AddTransient<RemoveHandler>();
    services.AddTransient<ConnectionHandler>();
  }

  internal static void AddRepos(this IServiceCollection services)
  {
    services.AddTransient<IConnectionDetailRepository, ConnectionDetailRepository>();
  }

  internal static void AddDatabase(this IServiceCollection services)
  {
    services.AddDbContext<RsshDbContext>();
  }

  internal static void AddCommands(this IServiceCollection services)
  {
    services.AddTransient<AddCommandWrapper>();
    services.AddTransient<ListCommandWrapper>();
    services.AddTransient<RemoveCommandWrapper>();
    services.AddTransient<ConnectCommandWrapper>();
  }
}
