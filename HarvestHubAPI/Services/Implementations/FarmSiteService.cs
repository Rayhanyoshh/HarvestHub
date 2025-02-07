using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Repositories.Interfaces;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.FarmSite;

public class FarmSiteService : IFarmSiteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FarmSiteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FarmSiteDTO>> GetAllFarmSitesAsync()
    {
        try
        {
            var sites = await _unitOfWork.FarmSites.GetAll();
            return _mapper.Map<IEnumerable<FarmSiteDTO>>(sites);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while getting all farm sites.", ex);
        }
    }

    public async Task<FarmSiteDTO> GetFarmSiteByIdAsync(int id)
    {
        try
        {
            var site = await _unitOfWork.FarmSites.GetById(id);
            return _mapper.Map<FarmSiteDTO>(site);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while getting the farm site with ID {id}.", ex);
        }
    }

    public async Task<FarmSiteDTO> CreateFarmSiteAsync(CreateFarmSiteDto createSiteDto)
    {
        try
        {
            var site = _mapper.Map<FarmSite>(createSiteDto);
            site.CreatedDate = DateTimeOffset.UtcNow;
            site.ModifiedDate = DateTimeOffset.UtcNow;
            site.IsDeleted = false;  // Set default value

            // Set properti CreatedUserId dan ModifiedUserId
            // Ini bisa diubah sesuai kebutuhan logika aplikasi Anda
            site.CreatedUserId = createSiteDto.CreatedUserId.HasValue ? createSiteDto.CreatedUserId.Value : 0; // Contoh pengaturan nilai default jika tidak ada
            site.ModifiedUserId = (int)site.CreatedUserId; // Contoh pengaturan nilai default jika tidak ada

            await _unitOfWork.FarmSites.Add(site);
            await _unitOfWork.Save();

            return _mapper.Map<FarmSiteDTO>(site);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while creating the farm site.", ex);
        }
    }

    public async Task UpdateFarmSiteAsync(FarmSiteDTO farmSiteDto)
    {
        try
        {
            var site = _mapper.Map<FarmSite>(farmSiteDto);
            site.ModifiedDate = DateTimeOffset.UtcNow;
            // Set properti ModifiedUserId, dll.

            _unitOfWork.FarmSites.Update(site);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while updating the farm site with ID {farmSiteDto.FarmSiteId}.", ex);
        }
    }

    public async Task DeleteFarmSiteAsync(int id)
    {
        try
        {
            await _unitOfWork.FarmSites.Delete(id);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while deleting the farm site with ID {id}.", ex);
        }
    }
}
