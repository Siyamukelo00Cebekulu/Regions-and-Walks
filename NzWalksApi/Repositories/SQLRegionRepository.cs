using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Models.Domain;

namespace NzWalksApi.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext dbContext;
        public SQLRegionRepository(NzWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region= await dbContext.Regions.FindAsync(id);
            if (region == null)
            {
                return null;
            }

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await dbContext.Regions.FindAsync(id);
        }


        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var regionsDomain = await dbContext.Regions.FindAsync(id);
            if (regionsDomain == null)
            {
                return null;
            }

            regionsDomain.Code = region.Code;
            regionsDomain.Name = region.Name;
            regionsDomain.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return regionsDomain;
        }
    }
}