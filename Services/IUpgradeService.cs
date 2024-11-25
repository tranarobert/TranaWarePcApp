using TranaWarePc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TranaWarePc.Services
{
    public interface IUpgradeService
    {
        Task<IEnumerable<Upgrade>> GetAllUpgrades();
        Task<Upgrade> GetUpgradeById(int id);
        Task CreateUpgrade(Upgrade upgrade);
        Task UpdateUpgrade(Upgrade upgrade);
        Task DeleteUpgrade(int id);
    }
}
