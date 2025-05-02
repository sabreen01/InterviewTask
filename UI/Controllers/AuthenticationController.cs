using domain.Models;
using l.applicaion.DTOs;
using l.applicaion.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [Authorize(Roles = "admin")]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        return Ok(await _authService.RegisterNewUser(registerDto));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        return Ok(await _authService.Login(loginDto));
    }

}
