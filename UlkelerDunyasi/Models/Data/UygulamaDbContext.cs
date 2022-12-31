using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UlkelerDunyasi.Models.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }

        public DbSet<Ulke> Ulkeler => Set<Ulke>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ulke>().HasData(
                new Ulke() { Id = 1, Ad = "Türkiye" },
                new Ulke() { Id = 2, Ad = "ABD" },
                new Ulke() { Id = 3, Ad = "Kanada" },
                new Ulke() { Id = 4, Ad = "Norveç" }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
