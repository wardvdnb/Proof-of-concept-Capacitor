using Microsoft.EntityFrameworkCore;
using Api.Models;
using System.Linq;

namespace Api.Data.Repositories
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly TicketContext _context;
        private readonly DbSet<Engineer> _engineers;

        public EngineerRepository(TicketContext dbContext)
        {
            _context = dbContext;
            _engineers = dbContext.Engineers;
        }

        public Engineer GetBy(string email)
        {
            return _engineers.Include(c => c.Tickets).SingleOrDefault(c => c.Email == email);
        }

        public void Add(Engineer engineer)
        {
            _engineers.Add(engineer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

