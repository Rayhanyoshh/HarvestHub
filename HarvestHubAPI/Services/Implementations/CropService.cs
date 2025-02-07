using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Repositories.Interfaces;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.Crop;

public class CropService : ICropService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CropService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CropDTO>> GetAllCropsAsync()
    {
        try
        {
            var crops = await _unitOfWork.Crops.GetAll();
            return _mapper.Map<IEnumerable<CropDTO>>(crops);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while getting all crops.", ex);
        }
    }

    public async Task<CropDTO> GetCropByIdAsync(int id)
    {
        try
        {
            var crop = await _unitOfWork.Crops.GetById(id);
            return _mapper.Map<CropDTO>(crop);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while getting the crop with ID {id}.", ex);
        }
    }

    public async Task<CropDTO> CreateCropAsync(CreateCropDto createCropDto)
    {
        try
        {
            var crop = _mapper.Map<Crop>(createCropDto);
            crop.CreatedDate = DateTimeOffset.UtcNow;
            crop.ModifiedDate = DateTimeOffset.UtcNow;
            crop.IsDeleted = false;  // Set default value

            // Set properti CreatedUserId dan ModifiedUserId
            // Ini bisa diubah sesuai kebutuhan logika aplikasi Anda
            crop.CreatedUserId = 0; // Contoh pengaturan nilai default
            crop.ModifiedUserId = 0; // Contoh pengaturan nilai default

            await _unitOfWork.Crops.Add(crop);
            await _unitOfWork.Save();

            return _mapper.Map<CropDTO>(crop);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while creating the crop.", ex);
        }
    }

    public async Task DeleteCropAsync(int id)
    {
        try
        {
            await _unitOfWork.Crops.Delete(id);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while deleting the crop with ID {id}.", ex);
        }
    }
}
