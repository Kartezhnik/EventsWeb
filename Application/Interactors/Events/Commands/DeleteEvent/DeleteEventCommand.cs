namespace Application.UseCases.Events.Commands.DeleteEvent
{
    public sealed record DeleteEventCommand
    {
        public DeleteEventCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
