using AirlinesApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace AirlinesApp.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Config> Configs { get; set; }

        public DbSet<Airline> Airlines { get; set; }

        public DbSet<Airplane> Airplanes { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<User> User { get; set; }

        public AppDbContext(DbContextOptions options): base(options) { }

    }
}