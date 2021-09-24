using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Arcaim.DbWrapper.Exceptions;
using Dapper;
using Microsoft.Extensions.Logging;

namespace Arcaim.DbWrapper
{
    public class DbWrapper : IDbWrapper
    {
        private Func<IDbConnection> _dbConnectionFactory;
        private readonly ILogger<DbWrapper> _logger;

        public DbWrapper(IDbConnection dbConnection, ILogger<DbWrapper> logger)
        {
            _dbConnectionFactory = () => dbConnection;
            _logger = logger;
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using var sqlConnection = _dbConnectionFactory();
                
                return await sqlConnection.ExecuteAsync(sql, param, transaction, commandTimeout,commandType);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,
                    @"An exception occurred while calling ExecuteAsync method with parameters:
                      sql = {0}
                      param = {1}",
                    sql, param);
                throw QueryFailedException.Create(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using var sqlConnection = _dbConnectionFactory();

                return await sqlConnection.QueryAsync<T>(sql, param, transaction, commandTimeout,commandType);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,
                    @"An exception occurred while calling QueryAsync method with parameters:
                      sql = {0}
                      param = {1}",
                    sql, param);
                throw QueryFailedException.Create(ex.Message);
            }
        }

        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, TResult>(string sql, Func<T1, T2, TResult> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using var sqlConnection = _dbConnectionFactory();

                return await sqlConnection.QueryAsync<T1, T2, TResult>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,
                    @"An exception occurred while calling QueryAsync method with parameters:
                      sql = {0}
                      map = {1}
                      param = {2}
                      transaction = {3}
                      buffered = {4}
                      splitOn = {5},
                      commandTimeout = {6}
                      commandType = {7}",
                    sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
                throw QueryFailedException.Create(ex.Message);
            }
        }
    }
}