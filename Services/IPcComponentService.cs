﻿using PawWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PawWebApp.Services
{
    public interface IPcComponentService
    {
        Task<IEnumerable<PcComponent>> GetAllComponentsAsync();
        Task<PcComponent> GetComponentByIdAsync(int id);
        Task CreateComponentAsync(PcComponent component);
        Task UpdateComponentAsync(PcComponent component);
        Task DeleteComponentAsync(int id);
    }
}

