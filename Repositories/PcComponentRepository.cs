using Microsoft.EntityFrameworkCore;
using TranaWarePcApp.Models;

namespace TranaWarePcApp.Repositories
{
    public class PcComponentRepository : IPcComponentRepository
    {
        private readonly TranaWareContext _context;

        public PcComponentRepository(TranaWareContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PcComponent>> GetAllAsync()
        {
            return await _context.PCComponents.ToListAsync();
        }

        public async Task<PcComponent> GetByIdAsync(int id)
        {
            return await _context.PCComponents.FindAsync(id);
        }

        public async Task CreateAsync(PcComponent component)
        {
            _context.PCComponents.Add(component);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PcComponent component)
        {
            _context.Entry(component).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var component = await GetByIdAsync(id);
            if (component != null)
            {
                _context.PCComponents.Remove(component);
                await _context.SaveChangesAsync();
            }
        }
    }
}
