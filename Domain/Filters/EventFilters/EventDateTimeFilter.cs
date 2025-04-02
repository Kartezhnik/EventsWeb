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
    public class EventDateTimeFilter : IFilter<Event>
    {
        private readonly DateTime _dateTime;
        public EventDateTimeFilter(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public Expression<Func<Event, bool>> Filter()
        {
            return e => e.DateTimeOfHolding == _dateTime;
        }
    }
}
