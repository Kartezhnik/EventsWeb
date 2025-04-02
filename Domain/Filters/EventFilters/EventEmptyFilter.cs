using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Filters.EventFilters
{
    public class EventEmptyFilter : IFilter<Event>
    {
        public EventEmptyFilter() { }

        public Expression<Func<Event, bool>> Filter()
        {
            return e => true;
        }
    }
}
