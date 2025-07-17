using Microsoft.EntityFrameworkCore;
using NzWalksApi.Models.Domain;

namespace NzWalksApi.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
                Seed data for Difficulties
                Easy, Medium, Hard
            */
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("de4399d4-754b-4e62-9b97-3137cab33240"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("09ef9156-61b2-4dd3-a0cc-2497cc7c2369"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("24e585bc-a10a-465f-99b4-61d1376bc8de"),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}