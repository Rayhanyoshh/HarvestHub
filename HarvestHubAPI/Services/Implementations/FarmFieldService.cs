using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarvestHubAPI.Models;
using HarvestHubAPI.Repositories.Interfaces;
using AutoMapper;
using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.FarmField;
using Microsoft.EntityFrameworkCore;

public class FarmFieldService : IFarmFieldService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FarmFieldService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FarmFieldDTO>> GetAllFarmFieldsAsync()
    {
        var fields = await _unitOfWork.FarmFields.AsQueryable().ToListAsync();
        return _mapper.Map<IEnumerable<FarmFieldDTO>>(fields);
    }

    public async Task<FarmFieldDTO> GetFarmFieldByIdAsync(int id)
    {
        var field = await _unitOfWork.FarmFields.GetById(id);
        return _mapper.Map<FarmFieldDTO>(field);
    }


    public async Task<FarmFieldDTO> CreateFarmFieldAsync(CreateFarmFieldDto createFieldDto)
    {
        var field = _mapper.Map<FarmField>(createFieldDto);
        field.FarmFieldCode = GenerateFarmFieldCode();  // Mengatur kode ladang
        field.CreatedDate = DateTimeOffset.UtcNow;
        field.ModifiedDate = DateTimeOffset.UtcNow;
        field.IsDeleted = false;  // Set default value

        await _unitOfWork.FarmFields.Add(field);
        await _unitOfWork.Save();

        return _mapper.Map<FarmFieldDTO>(field);
    }

    private string GenerateFarmFieldCode()
    {
        // Contoh fungsi untuk menghasilkan kode ladang unik
        return $"FF-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
    }

    public async Task UpdateFarmFieldAsync(FarmFieldDTO FarmFieldDTO)
    {
        var field = _mapper.Map<FarmField>(FarmFieldDTO);
        field.ModifiedDate = DateTimeOffset.UtcNow;
        // Set properti ModifiedUserId, dll.

        _unitOfWork.FarmFields.Update(field);
        await _unitOfWork.Save();
    }

    public async Task DeleteFarmFieldAsync(int id)
    {
        await _unitOfWork.FarmFields.Delete(id);
        await _unitOfWork.Save();
    }
}