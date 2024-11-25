using Microsoft.EntityFrameworkCore;
using PawWebApp.Models;

namespace PawWebApp.Repositories
{
    public class UpgradeRepository : IUpgradeRepository
    {
        private readonly TranaWareContext _context;
        public UpgradeRepository(TranaWareContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Upgrade>> GetAllUpgradesAsync()
        {
            return await _context.Upgrades.ToListAsync();
        }
        public async Task<Upgrade> GetUpgradeByIdAsync(int id)
        {
            return await _context.Upgrades.FindAsync(id);
        }
        public async Task CreateUpgradeAsync(Upgrade upgrade)
        {
            _context.Add(upgrade);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUpgradeAsync(Upgrade upgrade)
        {
            _context.Update(upgrade);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUpgradeAsync(int id)
        {
            var upgrade = await _context.Upgrades.FindAsync(id);
            if (upgrade != null)
            {
                _context.Upgrades.Remove(upgrade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
