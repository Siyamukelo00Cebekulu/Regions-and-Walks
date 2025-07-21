using NzWalksApi.Models.Domain;

namespace NzWalksApi.Repositories
{
    public interface IWalksRepository
    {
        Task<List<Walks>> GetAllAsync();

        Task<Walks?> GetByIdAsync(Guid id);

        Task<Walks> CreateAsync(Walks walks);

        Task<Walks?> UpdateAsync(Guid id, Walks walks);

        Task<Walks?> DeleteAsync(Guid id);
    }
}