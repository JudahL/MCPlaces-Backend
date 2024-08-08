using MCPlaces_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace MCPlaces_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        public DbSet<Place> Places { get; set; }
    }
}
