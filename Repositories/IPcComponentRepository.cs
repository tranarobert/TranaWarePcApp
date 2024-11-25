using TranaWarePc.Models;

namespace TranaWarePc.Repositories
{
    public interface IPcComponentRepository
    {
        Task<IEnumerable<PcComponent>> GetAllAsync();
        Task<PcComponent> GetByIdAsync(int id);
        Task CreateAsync(PcComponent component);
        Task UpdateAsync(PcComponent component);
        Task DeleteAsync(int id);
    }
}
