using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _caller;

        public AccountsController(
            UserManager<AppUser> userManager, 
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            ApplicationDbContext appDbContext)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        public string GetUserId()
        {
            return _caller.Claims.Single(c => c.Type == "id").Value;
        }
        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            await _userManager.AddToRoleAsync(userIdentity, "WRITER");
            /*
                        await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                        await _appDbContext.SaveChangesAsync();*/

            return new OkObjectResult("Account created");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            var u = await _appDbContext.Users.FindAsync(GetUserId());
            if (u == null)
                return NotFound("User doesn't exist!");
            return Ok(u);
        }

    }
}
