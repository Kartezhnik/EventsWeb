using Application.Abstractions.DataAccess;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Filters.EventFilters;
using Mapster;

namespace Application.Interactors.Participants.Queries.GetParticipantById
{
    public class GetParticipantByIdQueryHandler
    {
        private readonly IRepository<Participant> _repo;
        private readonly IUnitOfWork _unitOfWork;
        public GetParticipantByIdQueryHandler(IRepository<Participant> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ParticipantResponse> Handle(GetParticipantByIdQuery query, CancellationToken cancellationToken)
        {
            IFilter<Participant> filter = new ParticipantIdFilter(query.Id);
            IReadOnlyList<Participant> participants = await _repo.GetByFilterAsync(filter, cancellationToken);

            if(!participants.Any())
            {
                throw new Exception();
            }
            Participant participant = participants.First();

            return participant.Adapt<ParticipantResponse>();
        }
    }
}
