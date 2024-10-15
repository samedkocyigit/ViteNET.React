using ViteNET.React.Domain.Models.DTOs;

namespace ViteNET.React.Domain.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserDto> Register(UserRegisterDto userRegisterDto);
        Task<LoginResponseDto> Login(UserLoginDto userLoginDto);
        Task Logout();
    }

}
