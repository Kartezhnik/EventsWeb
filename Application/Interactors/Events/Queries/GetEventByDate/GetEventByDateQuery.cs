using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Events.Queries.GetEventByDate
{
    public sealed record GetEventByDateQuery
    {
        public GetEventByDateQuery(DateTime dateTime) 
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; init; }
    }
}
