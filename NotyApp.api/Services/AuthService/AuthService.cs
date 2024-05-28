
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NotyApp.api.contexts;
using NotyApp.api.models;
using NotyApp.api.requests.AuthRequest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NotyApp.api.Services.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext appDbContext, IConfiguration config)
        {
            _appDbContext = appDbContext;
            _config = config;
        }



        public async Task<string> Register(RegistrationRequest request)
        {

            try
            {

                User? user = await _appDbContext.users.Where(item => item.email == request.email).FirstOrDefaultAsync();

                if (user == null)
                {

                    await _appDbContext.users.AddAsync(new User
                    {

                        email = request.email,
                        password = HashPassword(request.password)
                    });


                    await _appDbContext.SaveChangesAsync();

                    return "success";


                }

                return "conflict";

            }catch(Exception ex)
            {

                throw;
            }

            
        }




        public async Task<string> Login(SignInRequest request)
        {

            try
            {
                User? user = await _appDbContext.users.Where(item => item.email == request.email).FirstOrDefaultAsync();


                if (user != null)
                {


                        return await GenerateTokenString(user);


                    
                }

                return "fail";

            }catch(Exception ex)
            {
                throw;
            }
        }




        public static string HashPassword(string password)
        {

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return passwordHash;

        }

        private async Task<string> GenerateTokenString(User user)
        {

            List<String> roles= new List<String>();

            var queryroles=await _appDbContext.userRoles.Include(i=>i.role).Where(j=>j.user_id==user.id).ToListAsync();

            foreach(var queryitem in queryroles)
            {

                roles.Add(queryitem.role.name);
            }

            

            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.NameIdentifier, user.id),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddMinutes(60);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiry,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
