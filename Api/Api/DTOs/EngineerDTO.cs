using Api.Models;
using System.Collections.Generic;

namespace Api.DTOs
{
    public class EngineerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }

        public EngineerDTO() { }

        public EngineerDTO(Engineer engineer) : this()
        {
            FirstName = engineer.FirstName;
            LastName = engineer.LastName;
            Email = engineer.Email;
            Tickets = engineer.Tickets;
        }
    }
}
