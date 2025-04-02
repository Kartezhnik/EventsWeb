using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Filters.EventFilters
{
    public sealed class ParticipantIdFilter : IFilter<Participant>
    {
        private readonly Guid _id;

        public ParticipantIdFilter(Guid id)
        {
            _id = id;
        }

        public Expression<Func<Participant, bool>> Filter()
        {
            return p => p.Id == _id;
        }
    }
}