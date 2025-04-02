namespace Application.Interactors.Events.Queries
{
    public sealed record EventResponse
    {
        public EventResponse(
            Guid id,
            string title,
            string category,
            string description,
            DateTime dateTimeOfHolding,
            string placeOfHolding,
            int maxAmountOfParticipants)
        {
            Id = id;
            Title = title;
            Description = description;
            DateTimeOfHolding = dateTimeOfHolding;
            PlaceOfHolding = placeOfHolding;
            Category = category;
            MaxAmountOfParticipants = maxAmountOfParticipants;
        }

        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime DateTimeOfHolding { get; init; }
        public string PlaceOfHolding { get; init; }
        public string Category { get; init; }
        public int MaxAmountOfParticipants { get; init; }
    }
}
