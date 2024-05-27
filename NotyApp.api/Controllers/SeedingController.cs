using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotyApp.api.Repositories.seedingRepository;

namespace NotyApp.api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeedingController : ControllerBase
    {

        private readonly ISeedingRepository _seedingRepository;



        public SeedingController(ISeedingRepository seedingRepository)
        {

            _seedingRepository = seedingRepository;
        }



        [HttpPost]
        public async Task<IActionResult> seedData()
        {

            try
            {
                await _seedingRepository.SeedData();
                return new JsonResult(new
                {


                    seeded = "success"
                });

            }catch(Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        
    }
}
