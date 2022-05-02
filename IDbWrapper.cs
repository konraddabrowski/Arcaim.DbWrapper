using System;
using System.Data;

namespace Arcaim.DbWrapper
{
  public interface IDbWrapper
  {
    public Func<IDbConnection> DbConnectionFactory { get; init; }
  }
}