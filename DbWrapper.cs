using System;
using System.Data;

namespace Arcaim.DbWrapper;

public class DbWrapper : IDbWrapper
{
  public Func<IDbConnection> DbConnectionFactory { get; init; }

  public DbWrapper(IDbConnection dbConnection)
  {
    DbConnectionFactory = () => dbConnection;
  }
}