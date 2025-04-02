using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.ParticipationFilter;

namespace Application.Interactors.Participations.Commands.DeleteParticipation
{
    public class DeleteParticipationCommandHandler
    {
        private readonly IRepository<Participation> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteParticipationCommandHandler(IRepository<Participation> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteParticipationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                IFilter<Participation> filter = new ParticipationIdFilter(command.Id);
                IReadOnlyList<Participation> participations = await _repo.GetByFilterAsync(filter, cancellationToken);

                if (!participations.Any())
                {
                    throw new Exception();
                }
                Participation participation = participations.First();

                await _repo.DeleteAsync(participation, cancellationToken);
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
