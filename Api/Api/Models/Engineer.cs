using System.Collections.Generic;
using System.Linq;

namespace Api.Models
{
    public class Engineer
    {
        #region Properties
        //add extra properties if needed
        public int EngineerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<Ticket> Tickets { get; private set; }
        #endregion

        #region Constructors
        public Engineer()
        {
            Tickets = new List<Ticket>();
        }

        public Engineer(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
        #endregion

        #region Methods
        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(new Ticket() { Id = ticket.Id, Title = ticket.Title, Description = ticket.Description, Engineer = this });
        }
        #endregion
    }
}

