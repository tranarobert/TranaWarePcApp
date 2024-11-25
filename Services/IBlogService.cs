using System.Collections.Generic;
using System.Threading.Tasks;
using TranaWarePc.Models;

namespace TranaWarePc.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(int id);
        Task CreateBlog(Blog blog);
        Task UpdateBlog(Blog blog);
        Task DeleteBlog(int id);
    }
}
