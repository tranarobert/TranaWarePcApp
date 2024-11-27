using TranaWarePcApp.Models;
using TranaWarePcApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TranaWarePcApp.Services
{
    public class PcComponentService : IPcComponentService
    {
        private readonly IPcComponentRepository _componentRepository;

        public PcComponentService(IPcComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public async Task<IEnumerable<PcComponent>> GetAllComponentsAsync()
        {
            return await _componentRepository.GetAllAsync();
        }

        public async Task<PcComponent> GetComponentByIdAsync(int id)
        {
            return await _componentRepository.GetByIdAsync(id);
        }

        public async Task CreateComponentAsync(PcComponent component)
        {
            await _componentRepository.CreateAsync(component);
        }

        public async Task UpdateComponentAsync(PcComponent component)
        {
            await _componentRepository.UpdateAsync(component);
        }

        public async Task DeleteComponentAsync(int id)
        {
            await _componentRepository.DeleteAsync(id);
        }
    }
}
