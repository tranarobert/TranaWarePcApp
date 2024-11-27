using Microsoft.EntityFrameworkCore;
using TranaWarePcApp.Models;
using TranaWarePcApp.Services;
using TranaWarePcApp.Repositories;

namespace TranaWarePcApp.Repositories
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
