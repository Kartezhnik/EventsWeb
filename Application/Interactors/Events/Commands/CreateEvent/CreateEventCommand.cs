    namespace Application.UseCases.Events.Commands.AddEvent
    {
        public sealed record CreateEventCommand
        {
            public CreateEventCommand(string title, 
                string description,
                DateTime dateTimeOfHolding,
                string placeOfHolding, 
                string category,
                int maxAmountOfParticipants) 
            {
                Title = title; 
                Description = description;
                DateTimeOfHolding = dateTimeOfHolding;
                PlaceOfHolding = placeOfHolding;
                Category = category;
                MaxAmountOfParticipants = maxAmountOfParticipants;
            }

            public string Title { get; init; }
            public string Description { get; init; }
            public DateTime DateTimeOfHolding { get; init; }
            public string PlaceOfHolding { get; init; }
            public string Category { get; init; }
            public int MaxAmountOfParticipants { get; init; }
        }
    }
