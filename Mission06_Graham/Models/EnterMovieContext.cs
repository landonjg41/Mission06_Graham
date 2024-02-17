using Microsoft.EntityFrameworkCore;

namespace Mission06_Graham.Models
{
    public class EnterMovieContext : DbContext
    {
        public EnterMovieContext(DbContextOptions<EnterMovieContext> options) : base (options) //constructor
        { 
        }

        public DbSet<EnterMovie> Applications { get; set; }
    }
}
