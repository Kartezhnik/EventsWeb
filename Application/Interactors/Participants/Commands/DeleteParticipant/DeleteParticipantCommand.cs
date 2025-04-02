namespace Application.Interactors.Participants.Commands.DeleteParticipant
{
    public sealed record DeleteParticipantCommand
    {
        public DeleteParticipantCommand(Guid id) 
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
