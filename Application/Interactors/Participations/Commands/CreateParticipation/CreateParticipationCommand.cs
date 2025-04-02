using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participations.Commands.CreateParticipation
{
    public sealed record CreateParticipationCommand
    {
        public CreateParticipationCommand(Guid eventId, Guid participantId)
        {
            EventId = eventId;
            ParticipantId = participantId;
        }
        public Guid EventId { get; init; }
        public Guid ParticipantId { get; init; }
    }
}
