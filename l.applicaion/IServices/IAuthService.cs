using l.applicaion.DTOs;

namespace l.applicaion.IServices
{
    public interface IAuthService
    {
        Task<bool> RegisterNewUser(RegisterDto registerDto);
        Task<LoginResponseDto> Login(LoginDto loginDto);
    }
}
