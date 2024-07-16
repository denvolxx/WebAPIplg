using Microsoft.AspNetCore.Mvc;
using WebAPIplg.Data.Authentication;
using WebAPIplg.DTO.Moderator;
using WebAPIplg.Models;

namespace WebAPIplg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponce<string>>> Register(ModeratorRegisterDTO request)
        {
            var response = await _authRepository.Register(
                new Moderator { UserName = request.UserName }, request.Password
            );

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponce<string>>> Login(ModeratorRegisterDTO request)
        {
            var response = await _authRepository.Login(request.UserName, request.Password);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
