using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private const int ApprovedStatusPk = 2;
        public ReadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("tag/{id}")]
        public async Task<ActionResult> GetBlogsByTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound("Tag is not found!");
            var q = await (from b in _context.Blogs.Where(r => r.BlogStatusPk == ApprovedStatusPk)
                           where b.Tags.Contains(tag)
                           select new
                           {
                               Pk = b.Pk,
                               Title = b.Title,
                               Img = b.Img,
                               Content = b.Content,
                               AppUser = new
                               {
                                   UserName = b.AppUser.UserName
                               },
                               Tags = b.Tags,
                               CreatedOn = b.CreatedOn
                           }).ToListAsync();
            return Ok(q);
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogsByKeyWords([FromBody] string query)
        {
            var q = await _context.Blogs.FromSqlRaw("EXEC Blogs_SEL_FreeText {0}", query).ToListAsync();
            return q;
        }

        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetLatestBlogs()
        {
            return await _context.Blogs
                .Where(r => r.BlogStatusPk == ApprovedStatusPk)
                .OrderByDescending(r => r.CreatedOn)
                .Include(r => r.AppUser).Take(10)
                .ToListAsync();
        }

        // GET: api/Readers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null || blog.BlogStatusPk != ApprovedStatusPk)
            {
                return NotFound();
            }

            return blog;
        }

        [HttpPost("like")]
        public async Task<ActionResult> LikeBlog([FromBody] Like like)
        {
            if (!BlogExists((int)like.BlogPk)) return BadRequest("The blog identity is wrong!");
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("comment")]
        public async Task<ActionResult> CommentBlog([FromBody] Comment comment)
        {
            if (!BlogExists((int)comment.BlogPk)) return BadRequest("The blog identity is wrong!");
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public bool BlogExists(int blogPk)
        {
            return _context.Blogs.Find(blogPk) != null;
        }

    }
}
