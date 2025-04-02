using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using Mapster;

namespace Application.Interactors.Events.Queries.GetEventByTitle
{
    public class GetEventByTitleQueryHandler
    {
        public readonly IRepository<Event> _repo;
        public GetEventByTitleQueryHandler(IRepository<Event> repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<EventResponse>> Handle(GetEventByTitleQuery query, CancellationToken cancellationToken)
        {
            IFilter<Event> filter = new EventTitleFilter(query.Title);
            IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(events.Any())
            {
                throw new Exception();
            }

            return events.Adapt<IReadOnlyList<EventResponse>>();
        }
    }
}
