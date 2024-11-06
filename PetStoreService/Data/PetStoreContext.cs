using Microsoft.EntityFrameworkCore;
using PetStoreService.Models;

namespace PetStoreService.Data
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().ToTable("Pet");
        }
    }
}