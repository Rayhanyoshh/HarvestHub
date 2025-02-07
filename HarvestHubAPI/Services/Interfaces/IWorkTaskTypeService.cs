using System.Collections.Generic;
using System.Threading.Tasks;
using HarvestHubProjectAPI.Models.DTO.WorkTaskType;

namespace HarvestHubAPI.Services.Interfaces
{
    public interface IWorkTaskTypeService
    {
        Task<IEnumerable<WorkTaskTypeDTO>> GetAllWorkTaskTypesAsync();
        Task<WorkTaskTypeDTO> GetWorkTaskTypeByCodeAsync(string code);
        Task<WorkTaskTypeDTO> CreateWorkTaskTypeAsync(CreateWorkTaskTypeDto createTypeDto);
        Task DeleteWorkTaskTypeAsync(string code);
    }
}