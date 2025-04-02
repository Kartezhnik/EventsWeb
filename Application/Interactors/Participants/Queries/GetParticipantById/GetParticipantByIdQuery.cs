using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participants.Queries.GetParticipantById
{
    public sealed record GetParticipantByIdQuery
    {
        public GetParticipantByIdQuery(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
