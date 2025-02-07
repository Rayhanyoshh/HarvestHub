using HarvestHubProjectAPI.Models.DTO.WorkTask;

namespace HarvestHubAPI.Services.Interfaces;

public interface IWorkTaskService
{
    Task<IEnumerable<WorkTaskDTO>> GetAllWorkTasksAsync();
    Task<WorkTaskDTO> GetWorkTaskByIdAsync(int id);
    Task<WorkTaskDTO> CreateWorkTaskAsync(CreateWorkTaskDto createTaskDto);
    Task UpdateWorkTaskAsync(WorkTaskDTO workTaskDto);
    Task DeleteWorkTaskAsync(int id);
    Task PauseWorkTaskAsync(int id);
    Task CancelWorkTaskAsync(int id);
    Task CompleteWorkTaskAsync(int id);
}