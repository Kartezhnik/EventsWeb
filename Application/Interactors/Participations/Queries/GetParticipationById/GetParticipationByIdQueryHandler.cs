using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.ParticipationFilter;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participations.Queries.GetParticipationById
{
    public class GetParticipationByIdQueryHandler
    {
        private readonly IRepository<Participation> _repo;

        public GetParticipationByIdQueryHandler(IRepository<Participation> repo)
        {
            _repo = repo;
        }

        public async Task<ParticipationResponse> Handle(GetParticipationByIdQuery query, CancellationToken cancellationToken)
        {
            IFilter<Participation> filter = new ParticipationIdFilter(query.Id);
            IReadOnlyList<Participation> participations = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(!participations.Any())
            {
                throw new Exception();
            }
            Participation participation = participations.First();

            return participation.Adapt<ParticipationResponse>();
        }
    }
}
