using FSDotNet.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSDotNet.Services.Contract
{
    public interface IUserService
    {
        public Task<ResponseDTO> GetAllUser();
    }
}
