using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawWebApp.Models;
using PawWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawWebApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace PawWebApp.Controllers
{

	public class BlogController : Controller
	{
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Authorize(Roles = "Administrator, User")]
        public async Task<IActionResult> Blog(int? page)
		{
			int pageSize = 3; // Number of blog posts per page
			int pageNumber = page ?? 1;

			var blogs = await _blogService.GetAllBlogs();
			//var paginatedBlogs = blogs
			//	.OrderByDescending(b => b.Id)
			//	.Skip((pageNumber - 1) * pageSize)
			//	.Take(pageSize)
			//	.ToList();

			return View(blogs);
		}

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> BlogPost(int id)
        {
            var blogPost = await _blogService.GetBlogById(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

    }
}
