using l.applicaion.CQRS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController()
        {
            
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> sayhello()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // or ClaimTypes.Name

            return Ok(new { userId });
        }
    }
}
