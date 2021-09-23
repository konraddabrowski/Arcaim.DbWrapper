using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Arcaim.DbWrapper
{
    public interface IDbWrapper
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
    }
}