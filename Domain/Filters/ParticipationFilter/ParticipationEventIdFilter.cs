using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters.ParticipationFilter
{
    public sealed class ParticipationEventIdFilter : IFilter<Participation>
    {
        private readonly Guid _eventId;

        public ParticipationEventIdFilter(Guid eventId)
        {
            _eventId = eventId;
        }

        public Expression<Func<Participation, bool>> Filter()
        {
            return p => p.EventId == _eventId;
        }
    }
}
