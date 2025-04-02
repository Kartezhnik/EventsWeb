using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using Mapster;

namespace Application.Interactors.Events.Queries.GetEventByPlaceOfHolding
{
    public class GetEventByPlaceOfHoldingQueryHandler
    {
        private readonly IRepository<Event> _repo;
        public GetEventByPlaceOfHoldingQueryHandler(IRepository<Event> repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<EventResponse>> Handle(GetEventByPlaceOfHoldingQuery query, CancellationToken cancellationToken)
        {
            IFilter<Event> filter = new EventPlaceOfHoldingFilter(query.PlaceOfHolding);
            IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(events.Any())
            {
                throw new Exception();
            }

            return events.Adapt<IReadOnlyList<EventResponse>>();
        }
    }
}
