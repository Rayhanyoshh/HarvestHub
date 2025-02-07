using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubAPI.Models.DTO.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace HarvestHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Mengautentikasi pengguna dan menghasilkan token JWT.
        /// </summary>
        ///
        /// <param name="loginRequest">Objek permintaan login yang berisi Email dan Password.</param>
        ///
        /// <returns>Token JWT dan waktu kadaluwarsa.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var response = await _authService.Authenticate(loginRequest);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Mendaftarkan pengguna baru.
        /// </summary>
        /// <param name="registerRequest">Objek permintaan pendaftaran yang berisi detail pengguna.</param>
        /// <returns>Pesan keberhasilan.</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.Register(registerRequest);
                return Ok(new { message = "Registration successful" });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}