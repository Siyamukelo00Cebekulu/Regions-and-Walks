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

        public Task<Walks?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Walks>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Walks?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Walks?> UpdateAsync(Guid id, Walks walks)
        {
            throw new NotImplementedException();
        }
    }
}