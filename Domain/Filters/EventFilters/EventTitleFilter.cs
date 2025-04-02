using Domain.Abstractions;
using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Filters.EventFilters
{
    public sealed class EventTitleFilter : IFilter<Event>
    {
        private readonly string _title;

        public EventTitleFilter(string title)
        {
            _title = title;   
        }

        public Expression<Func<Event, bool>> Filter()
        {
            return e => e.Title == _title;
        }
    }
}