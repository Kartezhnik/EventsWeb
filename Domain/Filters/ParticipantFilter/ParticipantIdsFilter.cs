using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters.ParticipantFilter
{
    public sealed class ParticipantIdsFilter : IFilter<Participant>
    {
        private readonly IReadOnlyList<Guid> _ids;

        public ParticipantIdsFilter(IReadOnlyList<Guid> ids)
        {
            _ids = ids;
        }

        public Expression<Func<Participant, bool>> Filter()
        {
            return p => _ids.Contains(p.Id);
        }
    }
}
