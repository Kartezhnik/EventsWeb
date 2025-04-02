using Application.Abstractions.DataAccess;
using Domain.Entities;

namespace Application.UseCases.Events.Commands.AddEvent
{
    public class CreateEventCommandHandler
    {
        private readonly IRepository<Event> _repo;
        private readonly IUnitOfWork _unitOfWork;

        CreateEventCommandHandler(IRepository<Event> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {

            try
            {
                Event @event = new Event(Guid.NewGuid(),
                command.Title,
                command.Category,
                command.Description,
                command.DateTimeOfHolding,
                command.PlaceOfHolding,
                command.MaxAmountOfParticipants);

                await _repo.CreateAsync(@event, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);

                return @event.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);

                throw ex;
            }
        }
    }
}
