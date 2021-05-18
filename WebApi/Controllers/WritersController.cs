using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace SkillSharing.Controllers
{
    [Authorize( Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _context;

        public WritersController(
            UserManager<AppUser> userManager,
            IBlogService blogService,
            IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _blogService = blogService;
            _context = context;
        }

        public string GetUserId()
        {
            return _caller.Claims.Single(c => c.Type == "id").Value;
        }

        // GET: api/Writers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs([FromQuery] string Status)
        {
            return await _blogService.GetUserBlogsByStatus(GetUserId(), Status);
        }

        // GET: api/Writers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _blogService.GetUserBlog(id, GetUserId());

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Writers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Pk)
            {
                return BadRequest("Blog must contain the identity");
            }
            if (!_blogService.UserBlogExists(id, GetUserId()))
            {
                return NotFound();
            }
            await _blogService.UpdateUserBlog(GetUserId(), blog);
            return NoContent();
        }

        // POST: api/Writers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            await _blogService.CreateUserBlog(GetUserId(), blog);
            return CreatedAtAction("GetBlog", new { id = blog.Pk }, blog);
        }

        [HttpPost("tag")]
        public async Task<ActionResult> PostTag(Tag tag)
        {
            await _context.AddAsync(tag);
            await _context.SaveChangesAsync();
            return new CreatedResult("Tag", tag);
        }

        // DELETE: api/Writers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if(!_blogService.UserBlogExists(id, GetUserId()))
            {
                return NotFound();
            }

            await _blogService.DeleteUserBlog(id, GetUserId());

            return NoContent();
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw()
        {
            var u = await _context.Users.FindAsync(GetUserId());
            u.WithdrawReputation = 0;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
