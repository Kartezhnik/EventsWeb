using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participants.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandHandler
    {
        private readonly IRepository<Participant> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteParticipantCommandHandler(IRepository<Participant> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteParticipantCommand command, CancellationToken cancellationToken)
        {
            try
            {
                IFilter<Participant> filter = new ParticipantIdFilter(command.Id);
                IReadOnlyList<Participant> participants = await _repo.GetByFilterAsync(filter, cancellationToken);
                Participant participant = participants.First();

                await _repo.DeleteAsync(participant, cancellationToken);
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
