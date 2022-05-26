using Api.Models;
using System.Threading.Tasks;
using System;

namespace Api.Data
{
    public class TicketDataInitializer
    {
        private readonly TicketContext _dbContext;

        public TicketDataInitializer(TicketContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with tickets, see DBContext         
                Engineer engineer = new Engineer { Email = "johndoe@example.com", FirstName = "John", LastName = "Doe" };
                _dbContext.Engineers.Add(engineer);
                Engineer engineer2 = new Engineer { Email = "janedoe@example.com", FirstName = "Jane", LastName = "Doe" };
                _dbContext.Engineers.Add(engineer2);
                _dbContext.Tickets.AddRange(
                    new Ticket { Title = "Install firewall", Created = DateTime.Now, Engineer = engineer, Description = "Set up a firewall for client X, the computers run on Windows 7." },
                    new Ticket { Title = "Repair screen", Created = DateTime.Now, Engineer = engineer2, Description = "Broken laptop screen, main cause is most likely a broken display controller." }
                );
                _dbContext.SaveChanges();
            }
        }
    }
}

