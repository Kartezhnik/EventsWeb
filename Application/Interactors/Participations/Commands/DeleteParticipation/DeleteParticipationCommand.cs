using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participations.Commands.DeleteParticipation
{
    public sealed record DeleteParticipationCommand
    {
        public DeleteParticipationCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
