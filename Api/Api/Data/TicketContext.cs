using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>().Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Ticket>().HasOne(t => t.Engineer).WithMany(e => e.Tickets);

            builder.Entity<Engineer>().Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Engineer>().Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Engineer>().Property(e => e.Email).IsRequired().HasMaxLength(100);
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
    }
}