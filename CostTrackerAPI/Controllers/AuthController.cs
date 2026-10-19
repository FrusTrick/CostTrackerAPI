using CostTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public AuthController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [Authorize]
        [HttpPost]
        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("GetUserRole")]
        public async Task<IActionResult> FetchUserRole()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            return Ok(roles);
        }
    }
}
