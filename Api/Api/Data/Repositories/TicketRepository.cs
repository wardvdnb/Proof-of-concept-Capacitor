using Microsoft.EntityFrameworkCore;
using Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;
        private readonly DbSet<Ticket> _tickets;

        public TicketRepository(TicketContext dbContext)
        {
            _context = dbContext;
            _tickets = dbContext.Tickets;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _tickets.Include(r => r.Engineer).ToList();
        }

        public Ticket GetBy(int id)
        {
            return _tickets.Include(r => r.Engineer).SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetTicket(int id, out Ticket ticket)
        {
            ticket = _context.Tickets.Include(t => t.Engineer).FirstOrDefault(t => t.Id == id);
            return ticket != null;
        }

        public void Add(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            _context.Update(ticket);
        }

        public void Delete(Ticket ticket)
        {
            _tickets.Remove(ticket);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> GetBy(string title = null)
        {
            var tickets = _tickets.Include(r => r.Engineer).AsQueryable();
            if (!string.IsNullOrEmpty(title))
                tickets = tickets.Where(r => r.Title.IndexOf(title) >= 0);
            return tickets.OrderBy(r => r.Title).ToList();
        }
    }
}
