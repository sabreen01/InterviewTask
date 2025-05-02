
using l.applicaion.DTOs;
using l.applicaion.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace l.applicaion.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return new LoginResponseDto { Message = "Invalid credentials" };

            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user.UserName, roles.FirstOrDefault(), user.Id);

            return new LoginResponseDto { Message = "Success",Token=token,ExpireAt=DateTime.Now.AddHours(1) };
        }

        public async Task<bool> RegisterNewUser(RegisterDto registerDto)
        {
            var user = new IdentityUser { UserName = registerDto.Username, Email = registerDto.Email };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return false;

            // Create role if not exists
            if (!await _roleManager.RoleExistsAsync(registerDto.Role))
                await _roleManager.CreateAsync(new IdentityRole(registerDto.Role));

            // Assign role
            await _userManager.AddToRoleAsync(user, registerDto.Role);

            return true;
        }

        private string GenerateJwtToken(string username, string role, string userId)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Role, role ?? "")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ryz2Mjg0nPPzWbh61EdwJ4jN55lN+6U9BJwhUZB6S/0="));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7053",
                audience: "https://localhost:4200",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
