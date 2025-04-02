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
    public sealed class EventPlaceOfHoldingFilter : IFilter<Event>
    {
        private readonly string _placeOfHolding;
        public EventPlaceOfHoldingFilter(string placeOfHolding)
        {
            _placeOfHolding = placeOfHolding;
        }

        public Expression<Func<Event, bool>> Filter()
        {
            return e => e.PlaceOfHolding == _placeOfHolding;
        }
    }
}
