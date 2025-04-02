using Application.Abstractions.DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Filters.EventFilters;

namespace Application.UseCases.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler
    {
        private readonly IRepository<Event> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventCommandHandler(IRepository<Event> repo, IUnitOfWork unitOfWork) 
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateEventCommand command, CancellationToken cancellationToken) 
        {
            try
            {
                EventIdFilter filter = new EventIdFilter(command.Id);
                IReadOnlyList<Event> events = await _repo.GetByFilterAsync(filter, cancellationToken);

                if (!events.Any())
                {
                    throw new EventNotFoundException(command.Id);
                }
                Event @event = events.First();

                await _repo.UpdateAsync(@event, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);

                throw ex;
            }
        }
    }
}
