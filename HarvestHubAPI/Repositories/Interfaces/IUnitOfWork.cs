using HarvestHubAPI.Models.Entities;

namespace HarvestHubAPI.Repositories.Interfaces;

using System;
using System.Threading.Tasks;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<User> Users { get; }
    IGenericRepository<FarmSite> FarmSites { get; }
    IGenericRepository<FarmField> FarmFields { get; }
    IGenericRepository<Crop> Crops { get; }
    IGenericRepository<WorkTask> WorkTasks { get; }
    IGenericRepository<WorkTaskType> WorkTaskTypes { get; }

    Task Save();
}
