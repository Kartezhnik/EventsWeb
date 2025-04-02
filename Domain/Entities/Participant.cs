using Domain.Primitives;
using System.Net.Mail;

namespace Domain.Entities
{
    public class Participant : Entity
    {
        public Participant(Guid id, 
            string name, 
            string surname, 
            DateOnly birthDate, 
            DateOnly registerDate, 
            MailAddress mailAddress) : base(id) 
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            RegisterDate = registerDate;
            MailAddress = mailAddress;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly RegisterDate { get; set; }
        public MailAddress MailAddress { get; set; }
    }
}
