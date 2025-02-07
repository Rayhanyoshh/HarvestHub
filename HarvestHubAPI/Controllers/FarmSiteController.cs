using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.FarmSite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HarvestHubAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FarmSitesController : ControllerBase
    {
        private readonly IFarmSiteService _farmSiteService;
        private readonly ILogger<FarmSitesController> _logger;

        public FarmSitesController(IFarmSiteService farmSiteService, ILogger<FarmSitesController> logger)
        {
            _farmSiteService = farmSiteService;
            _logger = logger;
        }

        // GET: api/FarmSites
        [HttpGet]
        public async Task<IActionResult> GetAllFarmSites()
        {
            _logger.LogInformation("Getting all farm sites");
            var sites = await _farmSiteService.GetAllFarmSitesAsync();
            return Ok(sites);
        }

        // GET: api/FarmSites/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFarmSiteById(int id)
        {
            _logger.LogInformation($"Getting farm site with ID {id}");
            var site = await _farmSiteService.GetFarmSiteByIdAsync(id);
            if (site == null)
            {
                _logger.LogWarning($"Farm site with ID {id} not found");
                return NotFound();
            }
            return Ok(site);
        }

        // POST: api/FarmSites
        [HttpPost]
        public async Task<IActionResult> CreateFarmSite([FromBody] CreateFarmSiteDto createSiteDto)
        {
            _logger.LogInformation("Creating new farm site");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid");
                return BadRequest(ModelState);
            }

            try
            {
                var site = await _farmSiteService.CreateFarmSiteAsync(createSiteDto);
                return CreatedAtAction(nameof(GetFarmSiteById), new { id = site.FarmSiteId }, site);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the farm site");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/FarmSites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFarmSite(int id, [FromBody] FarmSiteDTO farmSiteDto)
        {
            _logger.LogInformation($"Updating farm site with ID {id}");

            if (id != farmSiteDto.FarmSiteId)
            {
                _logger.LogWarning($"ID in the URL ({id}) does not match ID in the body ({farmSiteDto.FarmSiteId})");
                return BadRequest();
            }

            try
            {
                await _farmSiteService.UpdateFarmSiteAsync(farmSiteDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the farm site");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/FarmSites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmSite(int id)
        {
            _logger.LogInformation($"Deleting farm site with ID {id}");

            try
            {
                await _farmSiteService.DeleteFarmSiteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the farm site");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
