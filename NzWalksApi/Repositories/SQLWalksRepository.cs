using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Models.Domain;

namespace NzWalksApi.Repositories
{
    public class SQLWalksRepository : IWalksRepository
    {
        private readonly NzWalksDbContext dbContext;

        public SQLWalksRepository(NzWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walks> CreateAsync(Walks walks)
        {
            await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<Walks?> DeleteAsync(Guid id)
        {
            var walk = await dbContext.Walks.FindAsync(id);
            if (walk == null)
            {
                return null;
            }

            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<List<Walks>> GetAllAsync()
        {
             return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.FindAsync(id);
        }

        public async Task<Walks?> UpdateAsync(Guid id, Walks walk)
        {
            var walkDomain = await dbContext.Walks.FindAsync(id);

            if (walkDomain == null)
            {
                return null;
            }

            walkDomain.Name = walk.Name;
            walkDomain.Description = walk.Description;
            walkDomain.LengthInKm = walk.LengthInKm;
            walkDomain.WalkImageUrl = walk.WalkImageUrl;
            walkDomain.DifficultyId = walk.DifficultyId;

            await dbContext.SaveChangesAsync();

            return walkDomain;
        }
    }
}