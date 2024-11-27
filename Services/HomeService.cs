using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranaWarePcApp.Models;
using TranaWarePcApp.Repositories;

namespace TranaWarePcApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        private readonly ILogger<HomeRepository> _homeRepositoryLogger;

        public HomeService(IHomeRepository homeRepository, ILogger<HomeRepository> homeRepositoryLogger)
        {
            _homeRepository = homeRepository;
            _homeRepositoryLogger = homeRepositoryLogger;
        }

        public void AddNewsletter(Newsletter newsletter)
        {
            _homeRepository.AddNewsletterAsync(newsletter);
        }

        public void SaveChanges()
        {
            _homeRepository.SaveChangesAsync();
        }
    }
}
