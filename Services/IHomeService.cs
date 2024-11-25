
using PawWebApp.Models;

namespace PawWebApp.Services
{
    public interface IHomeService
    {
        void AddNewsletter(Newsletter newsletter);
        void SaveChanges();
    }
}
