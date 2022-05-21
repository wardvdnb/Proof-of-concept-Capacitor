using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;

namespace Api.Data
{
    public class TicketContext : IdentityDbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Ticket>()
            //    .HasMany(p => p.Engineers)
            //    .WithOne()
            //    .IsRequired()
            //    .HasForeignKey("TicketId"); //Shadow property

            builder.Entity<Ticket>().Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Ticket>().HasOne(t => t.Engineer).WithMany(e => e.Tickets);

            builder.Entity<Engineer>().Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Engineer>().Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Engineer>().Property(e => e.Email).IsRequired().HasMaxLength(100);
            //builder.Entity<Engineer>().HasMany(e => e.Tickets).WithOne(t => t.Engineer).HasForeignKey("EngineerId");

            //builder.Entity<EngineerFavorite>().HasKey(f => new { f.EngineerId, f.TicketId });
            //builder.Entity<EngineerFavorite>().HasOne(f => f.Engineer).WithMany(u => u.Tickets).HasForeignKey(f => f.EngineerId);
            //builder.Entity<EngineerFavorite>().HasOne(f => f.Ticket).WithMany().HasForeignKey(f => f.TicketId);

            //Another way to seed the database
            //builder.Entity<Ingredient>().HasData(
            //        //Shadow property can be used for the foreign key, in combination with anaonymous objects
            //        new { Id = 1, Name = "Tomatoes", Amount = (double?)0.75, Unit = "liter", TicketId = 1 },
            //        new { Id = 2, Name = "Minced Meat", Amount = (double?)500, Unit = "grams", TicketId = 1 },
            //        new { Id = 3, Name = "Onion", Amount = (double?)2, TicketId = 1 }
            //     );
            //builder.Entity<Ticket>().HasData(
            //     new Ticket { Id = 1, Title = "Install firewall", Created = DateTime.Now},
            //     new Ticket { Id = 2, Title = "Repair screen", Created = DateTime.Now }
            //);
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
    }
}