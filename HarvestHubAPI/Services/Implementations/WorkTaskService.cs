using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarvestHubAPI.Models;
using HarvestHubAPI.Repositories.Interfaces;
using AutoMapper;
using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Services.Interfaces;
using HarvestHubProjectAPI.Models.DTO.WorkTask;
using Microsoft.EntityFrameworkCore;

public class WorkTaskService : IWorkTaskService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WorkTaskService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkTaskDTO>> GetAllWorkTasksAsync()
    {
        try
        {
            var tasks = await _unitOfWork.WorkTasks.AsQueryable().ToListAsync();
            return _mapper.Map<IEnumerable<WorkTaskDTO>>(tasks);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while getting all work tasks.", ex);
        }
    }

    public async Task<WorkTaskDTO> GetWorkTaskByIdAsync(int id)
    {
        try
        {
            var task = await _unitOfWork.WorkTasks.GetById(id);
            return _mapper.Map<WorkTaskDTO>(task);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while getting the work task with ID {id}.", ex);
        }
    }

    public async Task<WorkTaskDTO> CreateWorkTaskAsync(CreateWorkTaskDto createTaskDto)
    {
        try
        {
            // Validasi FarmFieldId
            var farmField = await _unitOfWork.FarmFields.GetById(createTaskDto.FarmFieldId);
            if (farmField == null)
            {
                throw new Exception($"FarmField with ID {createTaskDto.FarmFieldId} does not exist.");
            }

            var task = _mapper.Map<WorkTask>(createTaskDto);
            task.CreatedDate = DateTimeOffset.UtcNow;
            task.ModifiedDate = DateTimeOffset.UtcNow;
            task.WorkTaskStatusCode = "Pending";  // Contoh status awal
            task.IsCompleted = false;
            task.IsDeleted = false;
            task.IsStarted = false;
            task.IsCancelled = false;
            // Set properti lain seperti CreatedUserId, ModifiedUserId

            await _unitOfWork.WorkTasks.Add(task);
            await _unitOfWork.Save();

            return _mapper.Map<WorkTaskDTO>(task);
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception("An error occurred while creating the work task.", ex);
        }
    }

    public async Task UpdateWorkTaskAsync(WorkTaskDTO workTaskDto)
    {
        try
        {
            var task = _mapper.Map<WorkTask>(workTaskDto);
            task.ModifiedDate = DateTimeOffset.UtcNow;
            // Set properti ModifiedUserId, dll.

            _unitOfWork.WorkTasks.Update(task);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while updating the work task with ID {workTaskDto.WorkTaskId}.", ex);
        }
    }

    public async Task DeleteWorkTaskAsync(int id)
    {
        try
        {
            await _unitOfWork.WorkTasks.Delete(id);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while deleting the work task with ID {id}.", ex);
        }
    }

    public async Task PauseWorkTaskAsync(int id)
    {
        try
        {
            var task = await _unitOfWork.WorkTasks.GetById(id);
            task.IsStarted = false;
            // Lakukan perubahan status lainnya

            _unitOfWork.WorkTasks.Update(task);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while pausing the work task with ID {id}.", ex);
        }
    }

    public async Task CancelWorkTaskAsync(int id)
    {
        try
        {
            var task = await _unitOfWork.WorkTasks.GetById(id);
            task.IsCancelled = true;
            task.CanceledDate = DateTimeOffset.UtcNow;
            // Lakukan perubahan status lainnya

            _unitOfWork.WorkTasks.Update(task);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while canceling the work task with ID {id}.", ex);
        }
    }

    public async Task CompleteWorkTaskAsync(int id)
    {
        try
        {
            var task = await _unitOfWork.WorkTasks.GetById(id);
            task.IsCompleted = true;
            // Lakukan perubahan status lainnya

            _unitOfWork.WorkTasks.Update(task);
            await _unitOfWork.Save();
        }
        catch (Exception ex)
        {
            // Log and rethrow exception with inner exception details
            throw new Exception($"An error occurred while completing the work task with ID {id}.", ex);
        }
    }
}
