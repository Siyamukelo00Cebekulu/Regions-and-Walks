using NzWalksApi.Models.Domain;

namespace NzWalksApi.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetById(Guid id);
    }
}