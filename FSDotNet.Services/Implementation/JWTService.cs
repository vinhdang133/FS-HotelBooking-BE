using FSDotNet.Common.DTO;
using FSDotNet.Common.DTO.Request;
using FSDotNet.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.Services.Implementation
{
    public class JWTService : IJWTService
    {
        public async Task<ResponseDTO> GenerateAccessToken(LoginRequestDTO dto)
        {
            ResponseDTO response = new ResponseDTO();



            return response;
        }
    }
}
