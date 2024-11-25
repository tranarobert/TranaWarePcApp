using TranaWarePc.Models;

namespace TranaWarePc.Repositories
{
    public interface IHomeRepository
    {
        void AddNewsletterAsync(Newsletter newsletter);
        void SaveChangesAsync();
    }
}
