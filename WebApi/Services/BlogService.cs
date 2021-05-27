using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Extensions;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IBlogService
    {
        Task<Blog> GetUserBlog(int pk, string userpk);
        Task<List<Blog>> GetUserBlogsByStatus(string userpk, int status);
        Task UpdateUserBlog(string userpk, Blog blog);
        Task CreateUserBlog(string userpk, Blog blog);
        Task DeleteUserBlog(int pk, string userpk);
        Task<List<Blog>> GetBlogsByStatus(int statusPk);
        bool UserBlogExists(int pk, string userpk);
        Task<Blog> GetBlog(int pk);
        Task UpdateBlogStatus(Blog blog);
        Task<List<Blog>> GetBlogsByTag(Tag tag);
        Task<List<Blog>> GetLatestBlogs();
        Task<List<Blog>> GetBlogsByTags(string[] idList);
    }
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool UserBlogExists(int pk, string userpk)
        {
            return _context.Blogs.Any(e => e.Pk == pk && e.UserPk == userpk);
        }

        public async Task CreateUserBlog(string userpk, Blog blog)
        {
            blog.UserPk = userpk;
            blog.BlogStatusPk = BlogState.Draft.Val();
            _context.AttachRange(blog.Tags);
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserBlog(int pk, string userpk)
        {
            _context.Blogs.Remove(await GetUserBlog(pk, userpk));
            await _context.SaveChangesAsync();
        }

        public async Task<Blog> GetBlog(int pk)
        {
            return await _context.Blogs.Where(r => r.Pk == pk)
                            .Include(r => r.Tags)
                            .Include(r => r.AppUser)
                            .Include(r => r.Comments).FirstAsync();
        }

        public async Task<List<Blog>> GetBlogsByStatus(int statusPk)
        {
            return await _context.Blogs
                           .Where(r => r.BlogStatusPk == statusPk)
                           .Include(r => r.BlogStatusPkNavigation)
                           .Include(r => r.AppUser)
                           .ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsByTag(Tag tag)
        {
            var q = await (from b in _context.Blogs.Where(r => r.BlogStatusPk == Constants.Blogs.ApprovedStatusPk)
                           where b.Tags.Contains(tag)
                           select new Blog
                           {
                               Pk = b.Pk,
                               Title = b.Title,
                               Img = b.Img,
                               Content = b.Content,
                               AppUser = new AppUser
                               {
                                   UserName = b.AppUser.UserName
                               },
                               Tags = b.Tags,
                               CreatedOn = b.CreatedOn
                           }).ToListAsync();
            return q;
        }

        public async Task<List<Blog>> GetLatestBlogs()
        {
            return await _context.Blogs
                          .Where(r => r.BlogStatusPk == Constants.Blogs.ApprovedStatusPk)
                          .OrderByDescending(r => r.CreatedOn)
                          .Include(r => r.AppUser).Take(Constants.Blogs.PagingSize)
                          .ToListAsync();
        }

        public async Task<Blog> GetUserBlog(int pk, string userpk)
        {
            var blog = await _context.Blogs.Where(r => r.Pk == pk
            && r.UserPk == userpk
            ).Include(r => r.Tags).FirstOrDefaultAsync();
            return blog;
        }

        public async Task<List<Blog>> GetUserBlogsByStatus(string userpk, int status)
        {
            var q = await _context.Blogs.Where(r => r.BlogStatusPk == status && r.UserPk == userpk).ToListAsync();
            // var q = await _context.BlogStatuses.Where(r => r.Pk == status)
            //         .Include(r => r.Blogs.Where(b => b.UserPk == userpk))
            //         .Select(r => r.Blogs.ToList())
            //         .FirstOrDefaultAsync();
            return q;
        }

        public async Task UpdateBlogStatus(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserBlog(string userpk, Blog blog)
        {
            var persistentBlog = await _context.Blogs.Where(r => r.Pk == blog.Pk).Include(r => r.Tags).FirstAsync();
            persistentBlog.BlogStatusPk = BlogState.Draft.Val();
            persistentBlog.Img = blog.Img;
            persistentBlog.Title = blog.Title;
            persistentBlog.Content = blog.Content;
            persistentBlog.Description = blog.Description;

            var tagsToRemove = persistentBlog.Tags.LeftExcept(blog.Tags);
            foreach (var t in tagsToRemove) persistentBlog.Tags.Remove(t);
            var tagsToAdd = blog.Tags.LeftExcept(persistentBlog.Tags);
            foreach (var t in tagsToAdd) persistentBlog.Tags.Add(t);

            await _context.Database.ExecuteSqlRawAsync(string.Format("SELECT public.upd_blog_vectors({0})", blog.Pk));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetBlogsByTags(string[] idList)
        {
            var q = await _context.Tags.Where(r => idList.Contains(r.Pk.ToString()))
                    .Include(r => r.Blogs)
                    .Select(r => r.Blogs).Take(Constants.Blogs.PagingSize).ToListAsync();
            List<Blog> list = new();
            foreach (var blogs in q) list.Concat(blogs);
            return list;
        }
    }
}
