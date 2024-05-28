using Microsoft.AspNetCore.Identity.Data;
using NotyApp.api.requests.AuthRequest;

namespace NotyApp.api.Services.AuthService
{
    public interface IAuthService
    {


        public Task<String> Register(RegistrationRequest request);

        public Task<String> Login(SignInRequest request);    



    }
}
