using Data.Entities;
using System.Data.Entity;

namespace Data.Context
{
    public class GamesDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Kind> Kinds { get; set; }

        public DbSet<Brand> Brands { get; set; }
    }
}
