using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using Mapster;

namespace Application.Interactors.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler
    {
        private readonly IRepository<Event> _repo;
        public GetAllEventsQueryHandler(IRepository<Event> repo) 
        {
            _repo = repo;        
        }

        public async Task<IReadOnlyList<EventResponse>> Handle(CancellationToken cancellationToken)
        {
            IFilter<Event> filter = new EventEmptyFilter();
            IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(!events.Any())
            {
                throw new ArgumentNullException(nameof(events));
            }
            
            return events.Adapt<IReadOnlyList<EventResponse>>();
        }
    }
}
