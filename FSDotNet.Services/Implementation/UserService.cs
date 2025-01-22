using FSDotNet.Common.DTO;
using FSDotNet.Common.DTO.BusinessCode;
using FSDotNet.Common.DTO.Request;
using FSDotNet.DAL.Contract;
using FSDotNet.DAL.Implementation;
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
        private IUnitOfWork _unitOfWork;

        public UserService(IGenericRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
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

        public Task<ResponseDTO> Login(LoginRequestDTO request)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO> SignUp(SignUpDTO request)
        {
            ResponseDTO dto = new ResponseDTO();
            try
            {
                var UserDb = await _userRepository.GetByExpression(a => a.Email == request.Email);
                if (UserDb != null)
                {
                    dto.BusinessCode = BusinessCode.EXISTED_USER;
                }
                else
                {
                    string passWordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password, 12);

                    var user = new User()
                    {
                        Id = Guid.NewGuid(),
                        Email = request.Email,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PasswordHash = passWordHash
                    };
                    await _userRepository.Insert(user);
                    await _unitOfWork.SaveChangeAsync();
                    dto.BusinessCode = BusinessCode.SIGN_UP_SUCCESSFULLY;
                }
            }
            catch (Exception ex)
            {
                dto.IsSuccess = false;
                dto.BusinessCode = BusinessCode.EXCEPTION;
            }
            return  dto;
        }
    }
}
