using Microsoft.EntityFrameworkCore;
using NzWalksApi.Domain;

namespace NzWalksApi.Data
{
    public class NzWalksDbCOntext : DbContext
    {
        public NzWalksDbCOntext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
    }
}