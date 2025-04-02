namespace Application.Interactors.Participations.Queries.GetParticipationsByEventId
{
    public sealed record GetParticipationsByEventIdQuery
    {
        public GetParticipationsByEventIdQuery(Guid eventId)
        {
            EventId = eventId;
        }
        public Guid EventId { get; init; }
    }
}
