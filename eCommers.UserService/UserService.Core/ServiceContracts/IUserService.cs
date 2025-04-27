using Common.Helper;
using UserService.Core.DTO;

namespace UserService.Core.ServiceContracts
{
    public interface IUserService
    {
        Task<BaseResponseModel<AuthenticationResponse>> Register (RegisterRequest loginRequest);
        Task<BaseResponseModel<AuthenticationResponse>> Login (LoginRequest loginRequest);
    }
}
