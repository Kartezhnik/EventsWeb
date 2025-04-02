using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Events.Queries.GetEventByTitle
{
    public sealed record GetEventByTitleQuery
    {
        public GetEventByTitleQuery(string title) 
        {
            Title = title;
        }

        public string Title { get; init; }
    }
}
