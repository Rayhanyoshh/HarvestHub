using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Repositories.Interfaces;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.WorkTaskType;

public class WorkTaskTypeService : IWorkTaskTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WorkTaskTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkTaskTypeDTO>> GetAllWorkTaskTypesAsync()
    {
        try
        {
            var types = await _unitOfWork.WorkTaskTypes.GetAll();
            return _mapper.Map<IEnumerable<WorkTaskTypeDTO>>(types);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while getting all work task types.", ex);
        }
    }

    public async Task<WorkTaskTypeDTO> GetWorkTaskTypeByCodeAsync(string code)
    {
        try
        {
            var type = await _unitOfWork.WorkTaskTypes.GetById(code);
            return _mapper.Map<WorkTaskTypeDTO>(type);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while getting the work task type with code {code}.", ex);
        }
    }

    public async Task<WorkTaskTypeDTO> CreateWorkTaskTypeAsync(CreateWorkTaskTypeDto createTypeDto)
    {
        try
        {
            var type = _mapper.Map<WorkTaskType>(createTypeDto);
            type.CreatedDate = DateTimeOffset.UtcNow;
            type.ModifiedDate = DateTimeOffset.UtcNow;
            type.IsDeleted = false;  // Set default value

            // Set properti CreatedUserId dan ModifiedUserId
            // Ini bisa diubah sesuai kebutuhan logika aplikasi Anda
            type.CreatedUserId = 0; // Contoh pengaturan nilai default
            type.ModifiedUserId = 0; // Contoh pengaturan nilai default

            await _unitOfWork.WorkTaskTypes.Add(type);
            await _unitOfWork.Save();

            return _mapper.Map<WorkTaskTypeDTO>(type);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while creating the work task type.", ex);
        }
    }

    public async Task DeleteWorkTaskTypeAsync(string code)
    {
        try
        {
            await _unitOfWork.WorkTaskTypes.Delete(code);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while deleting the work task type with code {code}.", ex);
        }
    }
}
