using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Events.Queries.GetEventByCategory
{
    public sealed record GetEventByCategoryQuery
    {
        public GetEventByCategoryQuery(string category) 
        {
            Category = category;
        }

        public string Category { get; init; }
    }
}
