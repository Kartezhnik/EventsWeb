using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events.Commands.UpdateEvent
{
    public sealed record UpdateEventCommand
    {
        public UpdateEventCommand(Guid id,
            string? title,
            string? description,
            DateTime? dateTimeOfHolding,
            string? placeOfHolding,
            string? category,
            int? maxAmountOfParticipants)
        {
            Id = id;
            Title = title;
            Description = description;
            DateTimeOfHolding = dateTimeOfHolding;
            PlaceOfHolding = placeOfHolding;
            Category = category;
            MaxAmountOfParticipants = maxAmountOfParticipants;
        }

        public Guid Id { get; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public DateTime? DateTimeOfHolding { get; init; }
        public string? PlaceOfHolding { get; init; }
        public string? Category { get; init; }
        public int? MaxAmountOfParticipants { get; init; }
    }
}
