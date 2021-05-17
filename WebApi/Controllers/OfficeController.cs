using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OfficeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OfficeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("blogs/status/{statusPk}")]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogsByStatus(int statusPk)
        {
            return await _context.Blogs
                .Where(r => r.BlogStatusPk == statusPk)
                .Include(r=>r.BlogStatusPkNavigation)
                .Include(r=>r.AppUser)
                .ToListAsync();
        }
        [HttpGet("blogs/{pk}")]
        public async Task<ActionResult> GetBlog(int pk)
        {
            var blog = await _context.Blogs.FindAsync(pk);
            if (blog == null) return NotFound("Blog doesn't exist");
            return Ok(blog);
        }

        [HttpPost("blogs/change")]
        public async Task<ActionResult> Post([FromQuery] int blogPk, [FromQuery] int statusPk)
        {
            var blog =  await _context.Blogs.FindAsync(blogPk);
            if (blog == null) return NotFound("Blog doesn't exist");
            blog.BlogStatusPk = statusPk;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("authors")]
        public async Task<ActionResult<ICollection<AppUser>>> Authors()
        {
            var q = await (from a in _context.Roles
                            join b in _context.UserRoles
                            on a.Id equals b.RoleId
                            join c in _context.Users
                            on b.UserId equals c.Id
                            where a.Name == "Writer"
                            select c).ToListAsync();
            return q;
        }

    }
}
