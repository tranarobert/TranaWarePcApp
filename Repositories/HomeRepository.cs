using Microsoft.EntityFrameworkCore;
using PawWebApp.Models;
using PawWebApp.Services;
using PawWebApp.Repositories;

namespace PawWebApp.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly TranaWareContext _context;
        private readonly ILogger<HomeRepository> _logger;

        public HomeRepository(TranaWareContext context, ILogger<HomeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddNewsletterAsync(Newsletter newsletter)
        {
            _context.Newsletters.Add(newsletter);
        }

        public void SaveChangesAsync()
        {
            _context.SaveChanges();
        }
    }


    
}
