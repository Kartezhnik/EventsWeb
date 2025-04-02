using Domain.Entities;

namespace Application.Abstractions.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Participant> UserRepository { get; }
        IRepository<Event> EventRepository { get; }

        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
