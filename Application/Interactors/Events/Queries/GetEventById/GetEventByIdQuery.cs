using Application.Abstractions.DataAccess;
using Domain.Entities;

namespace Application.Interactors.Events.Queries.GetEventById
{
    public sealed record GetEventByIdQuery
    {
        public GetEventByIdQuery(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
