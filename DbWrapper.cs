using System;
using System.Data;

namespace Arcaim.DbWrapper
{
    public class DbWrapper : IDbWrapper
    {
        private readonly Func<IDbConnection> _dbConnectionFactory;
        public IDbConnection DbConnection { get => _dbConnectionFactory(); }

        public DbWrapper(IDbConnection dbConnection)
        {
            _dbConnectionFactory = () => dbConnection;
        }

        // public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        // {
        //     try
        //     {
        //         using var sqlConnection = _dbConnectionFactory();
                
        //         return await sqlConnection.ExecuteAsync(sql, param, transaction, commandTimeout,commandType);
        //     }
        //     catch(Exception ex)
        //     {
        //         _logger.LogError(ex,
        //             @"An exception occurred while calling ExecuteAsync method with parameters:
        //               sql = {0}
        //               param = {1}",
        //             sql, param);
        //         throw QueryFailedException.Create(ex.Message);
        //     }
        // }
    }
}