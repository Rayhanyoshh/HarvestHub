using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.Crop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HarvestHubAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CropsController : ControllerBase
    {
        private readonly ICropService _cropService;
        private readonly ILogger<CropsController> _logger;

        public CropsController(ICropService cropService, ILogger<CropsController> logger)
        {
            _cropService = cropService;
            _logger = logger;
        }

        // GET: api/Crops
        [HttpGet]
        public async Task<IActionResult> GetAllCrops()
        {
            _logger.LogInformation("Getting all crops");
            var crops = await _cropService.GetAllCropsAsync();
            return Ok(crops);
        }

        // GET: api/Crops/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCropById(int id)
        {
            _logger.LogInformation($"Getting crop with ID {id}");
            var crop = await _cropService.GetCropByIdAsync(id);
            if (crop == null)
            {
                _logger.LogWarning($"Crop with ID {id} not found");
                return NotFound();
            }
            return Ok(crop);
        }

        // POST: api/Crops
        [HttpPost]
        public async Task<IActionResult> CreateCrop([FromBody] CreateCropDto createCropDto)
        {
            _logger.LogInformation("Creating new crop");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid");
                return BadRequest(ModelState);
            }

            try
            {
                var crop = await _cropService.CreateCropAsync(createCropDto);
                return CreatedAtAction(nameof(GetCropById), new { id = crop.CropId }, crop);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the crop");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Crops/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            _logger.LogInformation($"Deleting crop with ID {id}");

            try
            {
                await _cropService.DeleteCropAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the crop");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
