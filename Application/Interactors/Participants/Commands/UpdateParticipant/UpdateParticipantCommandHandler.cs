using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;

namespace Application.Interactors.Participants.Commands.UpdateParticipant
{
    public class UpdateParticipantCommandHandler
    {
        private readonly IRepository<Participant> _repo;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateParticipantCommandHandler(IRepository<Participant> repo, IUnitOfWork unitOfWork) 
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateParticipantCommand command, CancellationToken cancellationToken)
        {
            try
            {
                IFilter<Participant> filter = new ParticipantIdFilter(command.Id);
                IReadOnlyList<Participant> participants = await _repo.GetByFilterAsync(filter, cancellationToken);

                if(participants.Any())
                {
                    throw new Exception();
                }
                Participant participant = participants.First();

                await _repo.UpdateAsync(participant, cancellationToken);
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
