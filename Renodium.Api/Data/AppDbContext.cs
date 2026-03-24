using Microsoft.EntityFrameworkCore;
using Renodium.Api.Entities;

namespace Renodium.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Game> Games { get; set; }
    }
}
