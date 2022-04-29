using System.Data;

namespace Arcaim.DbWrapper
{
  public interface IDbWrapper
  {
    public IDbConnection DbConnection { get; }
  }
}