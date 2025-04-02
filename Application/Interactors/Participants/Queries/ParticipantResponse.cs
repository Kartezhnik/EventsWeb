using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interactors.Participants.Queries
{
    public sealed record ParticipantResponse
    {
        public ParticipantResponse(
            Guid id,
            string name,
            string surname,
            DateOnly birthDate,
            DateOnly registerDate,
            MailAddress mailAddress)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            RegisterDate = registerDate;
            MailAddress = mailAddress;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public DateOnly BirthDate { get; init; }
        public DateOnly RegisterDate { get; init; }
        public MailAddress MailAddress { get; init; }
    }
}
