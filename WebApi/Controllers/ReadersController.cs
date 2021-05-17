﻿using System;
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

        public ReadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("tag/{id}")]
        public async Task<ActionResult> GetBlogsByTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) return NotFound("Tag is not found!");
            var q = await (from b in _context.Blogs
                    where b.Tags.Contains(tag)
                    select new
                    {
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
            return await _context.Blogs.OrderByDescending(r=>r.CreatedOn).Include(r=>r.AppUser).Take(10).ToListAsync();
        }

        // GET: api/Readers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

    }
}