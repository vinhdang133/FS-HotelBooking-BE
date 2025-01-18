using FSDotNet.Common.DTO;
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
    }
}
