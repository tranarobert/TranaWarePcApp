
using TranaWarePcApp.Models;

namespace TranaWarePcApp.Services
{
    public interface IHomeService
    {
        void AddNewsletter(Newsletter newsletter);
        void SaveChanges();
    }
}
