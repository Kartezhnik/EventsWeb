using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participants.Queries.GetParticipantsByParticipations
{
    public sealed record GetParticipantsByParticipationsQuery
    {
        public GetParticipantsByParticipationsQuery(Guid eventId)
        {
            EventId = eventId;
        }
        public Guid EventId { get; init; }
    }
}
