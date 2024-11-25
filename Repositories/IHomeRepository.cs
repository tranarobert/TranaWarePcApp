using PawWebApp.Models;

namespace PawWebApp.Repositories
{
    public interface IHomeRepository
    {
        void AddNewsletterAsync(Newsletter newsletter);
        void SaveChangesAsync();
    }
}
