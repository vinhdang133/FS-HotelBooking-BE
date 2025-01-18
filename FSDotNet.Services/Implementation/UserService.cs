using FSDotNet.Common.DTO;
using FSDotNet.DAL.Contract;
using FSDotNet.DAL.Models;
using FSDotNet.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FSDotNet.Services.Implementation
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        
       

        public async Task<ResponseDTO> GetAllUser()
        {
            ResponseDTO dto = new ResponseDTO();

            try
            {
                dto.Data = await _userRepository.GetAllDataByExpression(null, 0, 0, null, true, a => a.Role);
            }
            catch (Exception ex)
            {
                dto.IsSuccess = false;
            }
            return dto;
        }
    }
}
