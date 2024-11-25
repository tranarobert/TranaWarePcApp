using TranaWarePc.Models;

namespace TranaWarePc.Repositories
{
    public interface IUpgradeRepository
    {
        Task<IEnumerable<Upgrade>> GetAllUpgradesAsync();
        Task<Upgrade> GetUpgradeByIdAsync(int id);
        Task CreateUpgradeAsync(Upgrade upgrade);
        Task UpdateUpgradeAsync(Upgrade upgrade);
        Task DeleteUpgradeAsync(int id);
    }
}
