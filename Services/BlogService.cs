using System.Collections.Generic;
using System.Threading.Tasks;
using PawWebApp.Models;
using PawWebApp.Repositories;

namespace PawWebApp.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return _blogRepository.GetAllBlogsAsync();
        }

        public Task<Blog> GetBlogById(int id)
        {
            return _blogRepository.GetBlogByIdAsync(id);
        }

        public Task CreateBlog(Blog blog)
        {
            return _blogRepository.CreateBlogAsync(blog);
        }

        public Task UpdateBlog(Blog blog)
        {
            return _blogRepository.UpdateBlogAsync(blog);
        }

        public Task DeleteBlog(int id)
        {
            return _blogRepository.DeleteBlogAsync(id);
        }
    }
}
