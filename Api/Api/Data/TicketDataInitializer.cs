using Microsoft.AspNetCore.Identity;
using Api.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Api.Data
{
    public class TicketDataInitializer
    {
        private readonly TicketContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public TicketDataInitializer(TicketContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with tickets, see DBContext         
                Engineer engineer = new Engineer { Email = "johndoe@example.com", FirstName = "John", LastName = "Doe" };
                _dbContext.Engineers.Add(engineer);
                await CreateUser(engineer.Email, "P@ssword1111");
                Engineer engineer2 = new Engineer { Email = "janedoe@example.com", FirstName = "Jane", LastName = "Doe" };
                _dbContext.Engineers.Add(engineer2);
                //engineer2.AddTicket(_dbContext.Tickets.First());
                await CreateUser(engineer2.Email, "P@ssword1111");
                _dbContext.Tickets.AddRange(
                    new Ticket { Title = "Install firewall", Created = DateTime.Now, Engineer = engineer, Description = "Set up a firewall for client X, the computers run on Windows 7." },
                    new Ticket { Title = "Repair screen", Created = DateTime.Now, Engineer = engineer2, Description = "Broken laptop screen, main cause is most likely a broken display controller." }
                );
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}

