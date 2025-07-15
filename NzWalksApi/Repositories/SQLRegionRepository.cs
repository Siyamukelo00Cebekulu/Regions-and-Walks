using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzWalksApi.Data;
using NzWalksApi.Models.Domain;

namespace NzWalksApi.Repositories
{
    public class SQLRegionRepository
    {
        private readonly NzWalksDbContext dbContext;
        public SQLRegionRepository(NzWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}