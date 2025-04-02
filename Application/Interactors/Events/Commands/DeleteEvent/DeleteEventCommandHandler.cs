using Application.Abstractions.DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Filters.EventFilters;
using System.Linq;

namespace Application.UseCases.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler
    {
        private readonly IRepository<Event> _repo;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEventCommandHandler(IRepository<Event> repo, IUnitOfWork unitOfWork) 
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                EventIdFilter filter = new EventIdFilter(command.Id);
                IReadOnlyList<Event> @events = await _repo.GetByFilterAsync(filter, cancellationToken);
                Event @event = @events.First();

                if (@event == null)
                {
                    throw new EventNotFoundException(command.Id);
                }

                await _repo.DeleteAsync(@event, cancellationToken);
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
