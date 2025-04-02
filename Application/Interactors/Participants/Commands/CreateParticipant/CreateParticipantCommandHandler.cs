using Application.Abstractions.DataAccess;
using Domain.Entities;

namespace Application.Interactors.Participants.Commands.CreateParticipant
{
    public class CreateParticipantCommandHandler
    {
        private readonly IRepository<Participant> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateParticipantCommandHandler(IRepository<Participant> repo, IUnitOfWork unitOfWork) 
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateParticipantCommand command, CancellationToken cancellationToken) 
        {
            try
            {
                Participant participant = new Participant(Guid.NewGuid(),
                command.Name,
                command.Surname,
                command.BirthDate,
                command.RegisterDate,
                command.MailAddress);

                await _repo.CreateAsync(participant, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                return participant.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw ex;
            }
        }
    }
}