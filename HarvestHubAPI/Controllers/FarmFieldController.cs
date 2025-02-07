using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubAPI.Models;
using HarvestHubProjectAPI.Models.DTO.FarmField;
using Microsoft.AspNetCore.Authorization;

namespace HarvestHubAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FarmFieldsController : ControllerBase
    {
        private readonly IFarmFieldService _farmFieldService;

        public FarmFieldsController(IFarmFieldService farmFieldService)
        {
            _farmFieldService = farmFieldService;
        }

        // GET: api/FarmFields
        [HttpGet]
        public async Task<IActionResult> GetAllFarmFields()
        {
            var fields = await _farmFieldService.GetAllFarmFieldsAsync();
            return Ok(fields);
        }

        // GET: api/FarmFields/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFarmFieldById(int id)
        {
            var field = await _farmFieldService.GetFarmFieldByIdAsync(id);
            if (field == null)
                return NotFound();
            return Ok(field);
        }

        // POST: api/FarmFields
        [HttpPost]
        public async Task<IActionResult> CreateFarmField([FromBody] CreateFarmFieldDto createFieldDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var field = await _farmFieldService.CreateFarmFieldAsync(createFieldDto);
            return CreatedAtAction(nameof(GetFarmFieldById), new { id = field.FarmFieldId }, field);
        }

        // PUT: api/FarmFields/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFarmField(int id, [FromBody] FarmFieldDTO farmFieldDto)
        {
            if (id != farmFieldDto.FarmFieldId)
                return BadRequest();

            await _farmFieldService.UpdateFarmFieldAsync(farmFieldDto);
            return NoContent();
        }

        // DELETE: api/FarmFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmField(int id)
        {
            await _farmFieldService.DeleteFarmFieldAsync(id);
            return NoContent();
        }
    }
}
