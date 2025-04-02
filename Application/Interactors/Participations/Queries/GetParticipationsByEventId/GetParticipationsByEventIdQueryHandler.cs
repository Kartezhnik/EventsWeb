using Application.Abstractions.DataAccess;
using Application.Interactors.AbstractionsForInteractors.Participations;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.ParticipationFilter;
using Mapster;

namespace Application.Interactors.Participations.Queries.GetParticipationsByEventId
{
    public class GetParticipationsByEventIdQueryHandler : IGetParticipationsByEventIdQueryHandler<GetParticipationsByEventIdQuery>
    {
        private readonly IRepository<Participation> _repo;

        public GetParticipationsByEventIdQueryHandler(IRepository<Participation> repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<ParticipationResponse>> Handle(GetParticipationsByEventIdQuery query,  CancellationToken cancellationToken)
        {
            IFilter<Participation> filter = new ParticipationEventIdFilter(query.EventId);
            IReadOnlyList<Participation> participations = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(!participations.Any())
            {
                throw new Exception();
            }

            return participations.Adapt<IReadOnlyList<ParticipationResponse>>();
        }

        public async Task<IReadOnlyList<Participation>> HandleForInteractors(GetParticipationsByEventIdQuery query, CancellationToken cancellationToken)
        {
            IFilter<Participation> filter = new ParticipationEventIdFilter(query.EventId);
            IReadOnlyList<Participation> participations = await _repo.GetByFilterAsync(filter, cancellationToken);

            if (!participations.Any())
            {
                throw new Exception();
            }

            return participations;
        }
    }
}
