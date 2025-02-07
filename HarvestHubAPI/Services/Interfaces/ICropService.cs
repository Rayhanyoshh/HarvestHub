using System.Collections.Generic;
using System.Threading.Tasks;
using HarvestHubProjectAPI.Models.DTO.Crop;

namespace HarvestHubAPI.Services.Interfaces
{
    public interface ICropService
    {
        Task<IEnumerable<CropDTO>> GetAllCropsAsync();
        Task<CropDTO> GetCropByIdAsync(int id);
        Task<CropDTO> CreateCropAsync(CreateCropDto createCropDto);
        Task DeleteCropAsync(int id);
    }
}