using Application.Abstractions.DataAccess;
using Application.Interactors.AbstractionsForInteractors.Participations;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using Domain.Filters.ParticipantFilter;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participants.Queries.GetParticipantsByParticipations
{
    public class GetParticipantsByParticipationsQueryHandler
    {
        private readonly IRepository<Participant> _repo;
        private readonly IGetParticipationsByEventIdQueryHandler<GetParticipantsByParticipationsQuery> _handler;

        public GetParticipantsByParticipationsQueryHandler(
            IRepository<Participant> repo,
            IGetParticipationsByEventIdQueryHandler<GetParticipantsByParticipationsQuery> handler)
        {
            _repo = repo;
            _handler = handler;
        }

        public async Task<IReadOnlyList<ParticipantResponse>> Handle(GetParticipantsByParticipationsQuery query, CancellationToken cancellationToken)
        { 
            IReadOnlyList<Participation> participations = await _handler.HandleForInteractors(query, cancellationToken);
            IReadOnlyList<Guid> participantIds = participations.Select(p => p.PartisipantId).ToList();
            IFilter<Participant> filter = new ParticipantIdsFilter(participantIds);
            IReadOnlyList<Participant> participants = await _repo.GetByFilterAsync(filter, cancellationToken);

            return participants.Adapt<IReadOnlyList<ParticipantResponse>>();
        }
    }
}
