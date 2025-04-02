using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Filters.EventFilters;
using Mapster;

namespace Application.Interactors.Events.Queries.GetEventById
{
    public class GetEventByIdQueryHandler
    {
        private readonly IRepository<Event> _repo;
        public GetEventByIdQueryHandler(IRepository<Event> repo)
        {
            _repo = repo;
        }

        public async Task<EventResponse> Handle(GetEventByIdQuery query, CancellationToken cancellationToken)
        {
            IFilter<Event> filter = new EventIdFilter(query.Id);
            IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

            if (!events.Any())
            {
                throw new EventNotFoundException(query.Id);
            }
            Event @event = events.First();

            return @event.Adapt<EventResponse>();
        }
    }
}
