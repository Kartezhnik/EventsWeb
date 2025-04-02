using Domain.Entities;

namespace Application.Interactors.AbstractionsForInteractors.Participations
{
    public interface IGetParticipationsByEventIdQueryHandler<T>
    {
        Task<IReadOnlyList<Participation>> HandleForInteractors(T query, CancellationToken cancellationToken);
    }
}
