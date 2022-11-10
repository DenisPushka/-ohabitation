using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Cohabitation> Cohabitations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<District> Districts { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
               optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OrderAccountSystem;Username=postgres;Password=ogr84Bqk3");

    }
}

