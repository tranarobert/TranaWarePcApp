using TranaWarePcApp.Models;

namespace TranaWarePcApp.Repositories
{
    public interface IHomeRepository
    {
        void AddNewsletterAsync(Newsletter newsletter);
        void SaveChangesAsync();
    }
}
