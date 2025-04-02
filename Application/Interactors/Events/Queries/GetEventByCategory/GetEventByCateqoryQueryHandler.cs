using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Filters.EventFilters;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Events.Queries.GetEventByCategory
{
    public class GetEventByCateqoryQueryHandler
    {
        private readonly IRepository<Event> _repo;

        public GetEventByCateqoryQueryHandler(IRepository<Event> repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<EventResponse>> Handle(GetEventByCategoryQuery query, CancellationToken cancellationToken)
        {
            IFilter<Event> filter = new EventCategoryFilter(query.Category);
            IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

            if (!events.Any())
            {
                throw new Exception();
            }

            return events.Adapt<IReadOnlyList<EventResponse>>();
        } 
    }
}
