using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class EventNotFoundException : NotFoundException
    {
        public EventNotFoundException(Guid id) : base($"The event with the id {id} was not found")
        {
        }
    }
}
