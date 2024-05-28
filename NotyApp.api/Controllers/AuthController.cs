using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotyApp.api.contexts;
using NotyApp.api.Dtos;
using NotyApp.api.models;
using NotyApp.api.requests.AuthRequest;
using NotyApp.api.Services.AuthService;

namespace NotyApp.api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;

        public AuthController(IAuthService authService,IMapper mapper,AppDbContext context)
        {

            _authService = authService;
            _mapper = mapper;
            _appDbContext = context;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {

            try
            {

                if (!ModelState.IsValid)
                {


                    return BadRequest(ModelState);
                }

                string authServiceActionResult=await _authService.Register(request);

                if (authServiceActionResult == "success")
                {

                    return new JsonResult(new
                    {

                        registered = "success"
                    });
                }

                    return Conflict();
                








            }catch (Exception ex)
            {

                return BadRequest(500);



            }




        }

        [HttpPost]

        public async Task<IActionResult> Login([FromBody] SignInRequest request)
        {

            try
            {

                if (!ModelState.IsValid) {

                    return BadRequest(ModelState);




                        }

             string authServiceActionResult = await _authService.Login(request);



                if (authServiceActionResult == "fail")
                {
                    return new JsonResult(new
                    {


                        error = "incorrect email or password"
                    });
                }

                User user = _appDbContext.users.Include(i=>i.sendedMessages).Include(i=>i.recievedMessages).Include(i=>i.addedContacts).
                    Include(i=>i.recievedContacts).Include(i=>i.roles).
                    
                    Where(i => i.email == request.email).FirstOrDefault();

                UserDto userdto = _mapper.Map<UserDto>(user);

               


                return new JsonResult(new
                {
                    user= userdto,
                    token = authServiceActionResult
                });


                   

            }
            catch(Exception ex)
            {

                return BadRequest(500);
            }



        }
    }
}
