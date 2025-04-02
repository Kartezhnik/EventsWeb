using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participations.Queries
{
    public sealed record ParticipationResponse
    {
        public ParticipationResponse(Guid id, Guid eventId, Guid participantId)
        {
            Id = id;
            EventId = eventId;
            ParticipantId = participantId;
        }

        public Guid Id { get; init; }
        public Guid EventId { get; init; }
        public Guid ParticipantId { get; init; }
    }
}
