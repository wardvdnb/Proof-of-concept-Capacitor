using System.Collections.Generic;

namespace Api.Models
{
    public interface ITicketRepository
    {
        Ticket GetBy(int id);
        IEnumerable<Ticket> GetAll();
        IEnumerable<Ticket> GetBy(string title = null);
        void Add(Ticket ticket);
        void Delete(Ticket ticket);
        void Update(Ticket ticket);
        void SaveChanges();
    }
}

