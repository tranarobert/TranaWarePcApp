using Microsoft.EntityFrameworkCore;
using TranaWarePcApp.Models;
using TranaWarePcApp.Repositories;
using TranaWarePcApp.Services;

namespace TranaWarePcApp.Services
{
    public class UpgradeService : IUpgradeService
    {
        private readonly IUpgradeRepository _upgradeRepository;
        public UpgradeService(IUpgradeRepository upgradeRepository)
        {
            _upgradeRepository = upgradeRepository;
        }
        public async Task<IEnumerable<Upgrade>> GetAllUpgrades()
        {
            return await _upgradeRepository.GetAllUpgradesAsync();
        }

        public async Task<Upgrade> GetUpgradeById(int id)
        {
            return await _upgradeRepository.GetUpgradeByIdAsync(id);
        }

        public async Task CreateUpgrade(Upgrade upgrade)
        {
            await _upgradeRepository.CreateUpgradeAsync(upgrade);
        }

        public async Task UpdateUpgrade(Upgrade upgrade)
        {
            await _upgradeRepository.UpdateUpgradeAsync(upgrade);
        }

        public async Task DeleteUpgrade(int id)
        {
            await _upgradeRepository.DeleteUpgradeAsync(id);
        }
    }
}
