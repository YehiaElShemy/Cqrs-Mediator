
using Cqrs_Mediator.Application.Abstractions.RepositoryContract;
using Cqrs_Mediator.InfraStructure.DataContext;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;



namespace Cqrs_Mediator.InfraStructure.Repositoryimplement
{
    public class DbConnectionFactory<T> : IDbConnectionFactory<T> where T : class
    {
        private readonly ApplicationContext _db;

        public DbConnectionFactory(ApplicationContext dbContext)
        {
            _db = dbContext;
        }
        private async Task<IDbConnection> openConnection()
        {
            var connection = _db.Database.GetDbConnection();
         
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

          
            return connection;
        }
        public async Task<IEnumerable<T>> QueryAsync(string sql, object parameters = null)
        {

            using (var connection = await openConnection())
            {
                return await connection.QueryAsync<T>(sql, parameters);

            }

        }

        public async Task<T> QueryFirstOrDefaultAsync(string sql, object? parameters = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            using (var connection = await openConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters, transaction);
            }
        }
        public async Task<int> ExecuteAsync(string sql, object? parameters = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            using (var connection = await openConnection())
            {
                return await connection.ExecuteAsync(sql, parameters, transaction);
            }
        }


    }
}
