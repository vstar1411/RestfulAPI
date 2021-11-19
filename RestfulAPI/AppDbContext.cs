//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
namespace RestfulAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Recipes> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipes>();
        }
    }
}