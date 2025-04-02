using Domain.Primitives;

namespace Domain.Entities
{
    public class Event : Entity
    {
        public Event(Guid id,
            string title,
            string category,
            string description,
            DateTime dateTimeOfHolding,
            string placeOfHolding,
            int maxAmountOfParticipants) : base(id)
        {
            Title = title;
            Description = description;
            DateTimeOfHolding = dateTimeOfHolding;
            PlaceOfHolding = placeOfHolding;
            Category = category;
            MaxAmountOfParticipants = maxAmountOfParticipants;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeOfHolding { get; set; }
        public string PlaceOfHolding { get; set; }
        public string Category { get; set; }
        public int MaxAmountOfParticipants { get; set; }
    }
}
