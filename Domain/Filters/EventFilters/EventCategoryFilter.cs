using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Filters.EventFilters
{
    public sealed class EventCategoryFilter : IFilter<Event>
    {
        private readonly string _category;

        public EventCategoryFilter(string category)
        {
            _category = category;
        }

        public Expression<Func<Event, bool>> Filter()
        {
            return e => e.Category == _category;
        }
    }
}
