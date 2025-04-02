using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using Mapster;

namespace Application.Interactors.Events.Queries.GetEventByDate
{
    public class GetEventByDateQueryHandler
    {
        private readonly IRepository<Event> _repo;
        public GetEventByDateQueryHandler(IRepository<Event> repo) 
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<EventResponse>> Handle(GetEventByDateQuery query, CancellationToken cancellationToken)
        {
            IFilter<Event> filter = new EventDateTimeFilter(query.DateTime);
            IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(!events.Any())
            {
                throw new Exception();
            }

            return events.Adapt<IReadOnlyList<EventResponse>>();
        }
    }
}
