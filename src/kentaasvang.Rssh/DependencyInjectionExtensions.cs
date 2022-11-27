using kentaasvang.Rssh.Implementations.Commands;
using kentaasvang.Rssh.Data;
using kentaasvang.Rssh.Interfaces.Handlers;
using kentaasvang.Rssh.Implementations.Handlers;
using kentaasvang.Rssh.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace kentaasvang.Rssh;

internal static class DependencyInjectionExtensions
{
  internal static void AddHandlers(this IServiceCollection services)
  {
    services.AddTransient<IAddHandler, AddHandler>();
    services.AddTransient<IListHandler, ListHandler>();
    services.AddTransient<IRemoveHandler, RemoveHandler>();
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
  }
}
