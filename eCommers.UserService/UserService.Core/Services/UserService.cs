using AutoMapper;
using Common.Helper;
using System.Net;
using UserService.Core.DTO;
using UserService.Core.Entities;
using UserService.Core.RepositoryContracts;
using UserService.Core.ServiceContracts;

namespace UserService.Core.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public async Task<BaseResponseModel<AuthenticationResponse>> Register(RegisterRequest loginRequest)
        {
            var baseResponse = new BaseResponseModel<AuthenticationResponse>();
            var user = _mapper.Map<ApplicationUser>(loginRequest);
            var registerdUser = await _userRepository.AddUser(user);
            if (registerdUser == null)
            {
                baseResponse.IsSuccess = false;
                baseResponse.ErrorCode = (int)HttpStatusCode.NotImplemented;
                baseResponse.Message = "User not registered";
                baseResponse.Data = new() { };
                return baseResponse;
            }
            baseResponse.IsSuccess = true;
            baseResponse.ErrorCode = (int)HttpStatusCode.OK;
            baseResponse.Data = (_mapper.Map<AuthenticationResponse>(user));
            baseResponse.Data.Token = string.Empty;
            baseResponse.Data.IsSuccess = true;
            return baseResponse;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<BaseResponseModel<AuthenticationResponse>> Login(LoginRequest loginRequest)
        {
            var baseResponse = new BaseResponseModel<AuthenticationResponse>();
            var user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                baseResponse.IsSuccess = false;
                baseResponse.ErrorCode = (int)HttpStatusCode.NotFound;
                baseResponse.Message = "User is not registered with current cridencials";
                baseResponse.Data = new() { };
                return baseResponse;
            }
            baseResponse.IsSuccess = true;
            baseResponse.ErrorCode = (int)HttpStatusCode.OK;
            baseResponse.Data = _mapper.Map<AuthenticationResponse>(user);
            baseResponse.Data.Token = string.Empty;
            baseResponse.Data.IsSuccess = true;
            return baseResponse;
        }
    }
}
