using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participations.Queries.GetParticipationById
{
    public sealed record GetParticipationByIdQuery
    {
        public GetParticipationByIdQuery(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
