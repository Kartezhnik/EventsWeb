using Application.Abstractions.DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participations.Commands.CreateParticipation
{
    public class CreateParticipationCommandHandler
    {
        private readonly IRepository<Participation> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateParticipationCommandHandler(IRepository<Participation> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateParticipationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Participation participation = new Participation(
                    Guid.NewGuid(),
                    command.EventId,
                    command.ParticipantId);

                await _repo.CreateAsync(participation, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return participation.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw ex;
            }
        }
    }
}
