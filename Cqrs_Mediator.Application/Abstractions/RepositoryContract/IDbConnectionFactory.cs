using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Abstractions.RepositoryContract
{
    public interface IDbConnectionFactory<T> where T : class
    {
        Task<IEnumerable<T>> QueryAsync(string sql, object parameters = null);
        Task<T> QueryFirstOrDefaultAsync(string sql, object? parameters = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);
        Task<int> ExecuteAsync(string sql, object? parameters = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);
    }
}
