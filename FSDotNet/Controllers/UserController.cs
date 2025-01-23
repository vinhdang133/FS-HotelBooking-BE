using FSDotNet.Common.DTO;
using FSDotNet.Common.DTO.Request;
using FSDotNet.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSDotNet.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
        {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ResponseDTO> GetAllUser()
        {
            return await _service.GetAllUser();
        }
        [HttpPost("sign-up")]
        public async Task<ResponseDTO> SignUp(SignUpDTO request)
        {
            return await _service.SignUp(request);
        }

        [HttpPost("login")]
        public async Task<ResponseDTO> Login(LoginRequestDTO dto)
        {
            return await _service.Login(dto);
        }
    }
}
