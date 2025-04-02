using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Events.Queries.GetEventByPlaceOfHolding
{
    public sealed record GetEventByPlaceOfHoldingQuery
    {
        public GetEventByPlaceOfHoldingQuery(string placeOfHolding) 
        {
            PlaceOfHolding = placeOfHolding;
        }

        public string PlaceOfHolding {  get; init; }
    }
}
