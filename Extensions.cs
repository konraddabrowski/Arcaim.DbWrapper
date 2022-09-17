using System;
using System.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Arcaim.DbWrapper;

public static class Extensions
{
  public static IServiceCollection AddDbWrapper(
    this IServiceCollection services,
    Func<IServiceProvider, IDbConnection> action)
  {
    services.AddScoped<IDbConnection>(action);
    services.AddScoped<IDbWrapper, DbWrapper>();

    return services;
  }
}