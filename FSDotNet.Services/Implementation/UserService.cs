using FSDotNet.Common.DTO;
using FSDotNet.Common.DTO.BusinessCode;
using FSDotNet.Common.DTO.Request;
using FSDotNet.DAL.Contract;
using FSDotNet.DAL.Implementation;
using FSDotNet.DAL.Models;
using FSDotNet.Services.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;



namespace FSDotNet.Services.Implementation
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository;
        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;
        public UserService(IGenericRepository<User> userRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
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

        public async Task<ResponseDTO> Login(LoginRequestDTO request)
        {
            ResponseDTO dto = new ResponseDTO();
           try{

                var UserDb = await _userRepository.GetByExpression(a => a.Email == request.Email, null);
                if(UserDb ==null){
                    dto.BusinessCode = BusinessCode.AUTH_NOT_FOUND;

                } else
                {
                    var isValid = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, UserDb.PasswordHash);
                    if (!isValid)
                    {
                        dto.BusinessCode = BusinessCode.WRONG_PASSWORD;
                    }
                    else
                    {
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var claims = new List<Claim>
                     {
                         new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                         new("AccountId", UserDb.Id.ToString()),
                         // new Claim(ClaimTypes.Role,userDb.Role.Name )
                     };
                        var token = new JwtSecurityToken(
                            issuer: _configuration["JwtSettings:Issuer"],
                            audience: _configuration["JwtSettings:Audience"],
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:AccessTokenExpirationMinutes"])),
                            signingCredentials: creds);

                        var tokenSign = new JwtSecurityTokenHandler().WriteToken(token);
                        dto.Data = tokenSign;
                    }
                }

            }catch (Exception ex)
            {
                dto.IsSuccess = false;

            }
            return dto;
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
