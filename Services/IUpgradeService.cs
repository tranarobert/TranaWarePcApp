using TranaWarePcApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TranaWarePcApp.Services
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
