using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubAPI.Models;
using HarvestHubProjectAPI.Models.DTO.WorkTask;
using Microsoft.AspNetCore.Authorization;

namespace HarvestHubAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTasksController : ControllerBase
    {
        private readonly IWorkTaskService _workTaskService;

        public WorkTasksController(IWorkTaskService workTaskService)
        {
            _workTaskService = workTaskService;
        }

        // GET: api/WorkTasks
        [HttpGet]
        public async Task<IActionResult> GetAllWorkTasks()
        {
            var tasks = await _workTaskService.GetAllWorkTasksAsync();
            return Ok(tasks);
        }

        // GET: api/WorkTasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkTaskById(int id)
        {
            var task = await _workTaskService.GetWorkTaskByIdAsync(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        // POST: api/WorkTasks
        [HttpPost]
        public async Task<IActionResult> CreateWorkTask([FromBody] CreateWorkTaskDto createTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _workTaskService.CreateWorkTaskAsync(createTaskDto);
            return CreatedAtAction(nameof(GetWorkTaskById), new { id = task.WorkTaskId }, task);
        }

        // PUT: api/WorkTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkTask(int id, [FromBody] WorkTaskDTO workTaskDto)
        {
            if (id != workTaskDto.WorkTaskId)
                return BadRequest();

            await _workTaskService.UpdateWorkTaskAsync(workTaskDto);
            return NoContent();
        }

        // DELETE: api/WorkTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkTask(int id)
        {
            await _workTaskService.DeleteWorkTaskAsync(id);
            return NoContent();
        }

        // Actions for Pause, Cancel, Complete
        [HttpPut("{id}/pause")]
        public async Task<IActionResult> PauseWorkTask(int id)
        {
            await _workTaskService.PauseWorkTaskAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelWorkTask(int id)
        {
            await _workTaskService.CancelWorkTaskAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteWorkTask(int id)
        {
            await _workTaskService.CompleteWorkTaskAsync(id);
            return NoContent();
        }
    }
}
