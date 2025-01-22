using FSDotNet.Common.DTO;
using FSDotNet.Common.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.Services.Contract
{
    public interface IJWTService
    {
        public Task<ResponseDTO> GenerateAccessToken(LoginRequestDTO dto);
            
    }
}
