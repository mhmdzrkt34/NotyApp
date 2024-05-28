using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotyApp.api.contexts;
using NotyApp.api.models;
using NotyApp.api.requests.UserRequest;
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
        public async Task<IActionResult> sendMessage([FromBody] MessageRequest request) {


            try
            {



                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User? usersernder = await _appDbContext.users.Where(item => item.id == request.sender_id).FirstOrDefaultAsync();


                User? userreciever = await _appDbContext.users.Where(item => item.id == request.reciever_id).FirstOrDefaultAsync();

                if (usersernder == null || userreciever == null)
                {


                    return new JsonResult(new
                    {

                        error = "sender or reciever not found"
                    });
                }

                Message message = new Message
                {
                    message = request.message,
                    type = request.type,
                    sender_id = request.sender_id,
                    reciever_id = request.reciever_id
                };




                await _appDbContext.messages.AddAsync(message);
                await _appDbContext.SaveChangesAsync();
                return new JsonResult(new
                {   id=message.id,
                    message=message.message,
                    type=message.type,

                    time=message.time,
                    sender_id= message.sender_id,
                    reciever_id= message.reciever_id



                });

            }catch(Exception ex)
            {

                return BadRequest(505);
            }



        }
    }
}
