using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HarvestHubAPI.Controllers
{
    [Authorize]  // This ensures that all actions in this controller require authentication
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    {
        // GET: api/Protected
        [HttpGet]
        public IActionResult GetProtectedData()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.Identity.Name;

            return Ok(new
            {
                Message = "This is protected data.",
                UserId = userId,
                Username = username
            });
        }

        // Additional protected actions can be added here
    }
}