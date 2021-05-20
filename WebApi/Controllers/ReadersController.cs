using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlogService _blogService;
        public ReadersController(ApplicationDbContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        //TODO: can have multiple tags 
        [HttpGet("tag")]
        public async Task<ActionResult> GetBlogsByTag([FromQuery] string ids)
        {
            string[] idList = ids.Split(",");
            var blogs = await _blogService.GetBlogsByTags(idList);
            return Ok(blogs);
        }

        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogsByKeyWords([FromBody] string query)
        {
            var q = await _context.Blogs.FromSqlRaw("select * from Blogs_Sel_Query({0})", query).ToListAsync();
            return q;
        }

        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetLatestBlogs()
        {
            return await _blogService.GetLatestBlogs();
          
        }

        // GET: api/Readers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _blogService.GetBlog(id);

            if (blog == null || blog.BlogStatusPk != Constants.Blogs.ApprovedStatusPk)
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

        //TODO: GetAllTags endpoint to provide tags

        public bool BlogExists(int blogPk)
        {
            return _context.Blogs.Find(blogPk) != null;
        }

    }
}
