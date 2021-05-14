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

        public WritersController(UserManager<AppUser> userManager, IBlogService blogService, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _blogService = blogService;
        }

        public string GetUserId()
        {
            return _caller.Claims.Single(c => c.Type == "id").Value;
        }

        // GET: api/Writers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _blogService.GetUserBlogs(GetUserId());
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
                return BadRequest();
            }

            try
            {
                await _blogService.UpdateUserBlog(GetUserId(), blog);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_blogService.BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
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

        // DELETE: api/Writers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            if(!_blogService.BlogExists(id))
            {
                return NotFound();
            }

            await _blogService.DeleteUserBlog(id, GetUserId());

            return NoContent();
        }

    }
}
