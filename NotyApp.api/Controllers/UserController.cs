using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotyApp.api.contexts;
using NotyApp.api.models;
using System.Security.Claims;

namespace NotyApp.api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            User user = await _appDbContext.users.AsNoTracking().Include(i=>i.roles).Include(i=>i.addedContacts).Include(i=>i.recievedContacts).Include(i=>i.sendedMessages).Include(i=>i.recievedMessages).Where(item => item.id == userId).FirstAsync();

            return new JsonResult(new
            {

                user
            });


        }
    }
}
