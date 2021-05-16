using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IBlogService
    {
        Task<Blog> GetUserBlog(int pk, string userpk);
        Task<List<Blog>> GetUserBlogs(string userpk);
        Task UpdateUserBlog(string userpk, Blog blog);
        Task CreateUserBlog(string userpk, Blog blog);
        Task DeleteUserBlog(int pk, string userpk);
        bool BlogExists(int pk, string userpk);
    }
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool BlogExists(int pk, string userpk)
        {
            return _context.Blogs.Any(e => e.Pk == pk && e.UserPk == userpk);
        }

        public async Task CreateUserBlog(string userpk, Blog blog)
        {
            blog.UserPk = userpk;
            blog.BlogStatusPk = 1;
            _context.AttachRange(blog.Tags);
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserBlog(int pk, string userpk)
        {
            _context.Blogs.Remove(await GetUserBlog(pk, userpk));
            await _context.SaveChangesAsync();
        }

        public async Task<Blog> GetUserBlog(int pk, string userpk)
        {
            var blog = await _context.Blogs.Where(r=>r.Pk == pk 
            && r.UserPk == userpk
            ).FirstOrDefaultAsync();
            return blog;
        }

        public async Task<List<Blog>> GetUserBlogs(string userpk)
        {
            return await _context.Blogs
                .Where(r => r.UserPk == userpk)
                .ToListAsync();
        }

        public async Task UpdateUserBlog(string userpk, Blog blog)
        {
            blog.UserPk = userpk;
            blog.BlogStatusPk = 1;
            _context.Update(blog);
            await _context.SaveChangesAsync();
        }
    }
}
