using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Participation : Entity
    {
        public Participation(Guid id, Guid eventId, Guid partisipantId) : base(id)
        {
            EventId = eventId;
            PartisipantId = partisipantId;
        }
        public Guid EventId { get; set; }
        public Guid PartisipantId { get; set; }
    }
}
