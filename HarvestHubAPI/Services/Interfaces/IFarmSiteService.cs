using System.Collections.Generic;
using System.Threading.Tasks;
using HarvestHubProjectAPI.Models.DTO.FarmSite;

namespace HarvestHubAPI.Services.Interfaces
{
    public interface IFarmSiteService
    {
        Task<IEnumerable<FarmSiteDTO>> GetAllFarmSitesAsync();
        Task<FarmSiteDTO> GetFarmSiteByIdAsync(int id);
        Task<FarmSiteDTO> CreateFarmSiteAsync(CreateFarmSiteDto createSiteDto);
        Task UpdateFarmSiteAsync(FarmSiteDTO farmSiteDto);
        Task DeleteFarmSiteAsync(int id);
    }
}