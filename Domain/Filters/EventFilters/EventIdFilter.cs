using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Filters.EventFilters
{
    public sealed class EventIdFilter : IFilter<Event>
    {
        private readonly Guid _id;

        public EventIdFilter(Guid id)
        {
            _id = id;
        }

        public Expression<Func<Event, bool>> Filter()
        {
            return e => e.Id == _id;
        }
    }
}