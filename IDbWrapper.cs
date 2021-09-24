using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Arcaim.DbWrapper
{
    public interface IDbWrapper
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TResult>> QueryAsync<T1, T2, TResult>(string sql, Func<T1, T2, TResult> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
    }
}