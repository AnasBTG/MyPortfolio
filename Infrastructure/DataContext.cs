using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValue("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValue("NEWID()");

            modelBuilder.Entity<Owner>().HasData(
            new Owner
            {
                Id = Guid.NewGuid(),
                FullName = "Anass BOUTAGHRASSA",
                Avatar = "avatar.jpg",
                Profil = "Senior Software Developer"
            });
        }

        public DbSet<Owner> owner { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }
    }
}
