
using TranaWarePc.Models;

namespace TranaWarePc.Services
{
    public interface IHomeService
    {
        void AddNewsletter(Newsletter newsletter);
        void SaveChanges();
    }
}
