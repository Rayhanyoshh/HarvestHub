using HarvestHubProjectAPI.Models.DTO.FarmField;

namespace HarvestHubAPI.Services.Interfaces;

public interface IFarmFieldService
{
    Task<IEnumerable<FarmFieldDTO>> GetAllFarmFieldsAsync();
    Task<FarmFieldDTO> GetFarmFieldByIdAsync(int id);
    Task<FarmFieldDTO> CreateFarmFieldAsync(CreateFarmFieldDto createFieldDto);
    Task UpdateFarmFieldAsync(FarmFieldDTO farmFieldDto);
    Task DeleteFarmFieldAsync(int id);
}