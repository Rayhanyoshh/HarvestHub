using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.WorkTaskType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HarvestHubAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTaskTypesController : ControllerBase
    {
        private readonly IWorkTaskTypeService _workTaskTypeService;
        private readonly ILogger<WorkTaskTypesController> _logger;

        public WorkTaskTypesController(IWorkTaskTypeService workTaskTypeService, ILogger<WorkTaskTypesController> logger)
        {
            _workTaskTypeService = workTaskTypeService;
            _logger = logger;
        }

        // GET: api/WorkTaskTypes
        [HttpGet]
        public async Task<IActionResult> GetAllWorkTaskTypes()
        {
            _logger.LogInformation("Getting all work task types");
            var types = await _workTaskTypeService.GetAllWorkTaskTypesAsync();
            return Ok(types);
        }

        // GET: api/WorkTaskTypes/{code}
        [HttpGet("{code}")]
        public async Task<IActionResult> GetWorkTaskTypeByCode(string code)
        {
            _logger.LogInformation($"Getting work task type with code {code}");
            var type = await _workTaskTypeService.GetWorkTaskTypeByCodeAsync(code);
            if (type == null)
            {
                _logger.LogWarning($"Work task type with code {code} not found");
                return NotFound();
            }
            return Ok(type);
        }

        // POST: api/WorkTaskTypes
        [HttpPost]
        public async Task<IActionResult> CreateWorkTaskType([FromBody] CreateWorkTaskTypeDto createTypeDto)
        {
            _logger.LogInformation("Creating new work task type");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid");
                return BadRequest(ModelState);
            }

            try
            {
                var type = await _workTaskTypeService.CreateWorkTaskTypeAsync(createTypeDto);
                return CreatedAtAction(nameof(GetWorkTaskTypeByCode), new { code = type.WorkTaskTypeCode }, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the work task type");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/WorkTaskTypes/{code}
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteWorkTaskType(string code)
        {
            _logger.LogInformation($"Deleting work task type with code {code}");

            try
            {
                await _workTaskTypeService.DeleteWorkTaskTypeAsync(code);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the work task type");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
