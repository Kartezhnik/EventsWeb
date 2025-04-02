using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Abstractions.DataAccess
{
    public interface IRepository<T>
    {
        Task<IReadOnlyList<T>> GetByFilterAsync(IFilter<T> filter, CancellationToken cancellationToken);
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}