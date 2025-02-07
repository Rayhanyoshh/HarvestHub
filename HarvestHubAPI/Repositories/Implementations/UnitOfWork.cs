using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Repositories.Interfaces;

namespace HarvestHubAPI.Repositories.Implementations;
using System.Threading.Tasks;

public class UnitOfWork : IUnitOfWork
{
    private readonly HarvestHubContext _context;

    private IGenericRepository<User> _users;
    private IGenericRepository<FarmSite> _farmSites;
    private IGenericRepository<FarmField> _farmFields;
    private IGenericRepository<Crop> _crops;
    private IGenericRepository<WorkTaskType> _workTaskTypes;
    private IGenericRepository<WorkTask> _workTasks;

    public UnitOfWork(HarvestHubContext context)
    {
        _context = context;
    }

    public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
    public IGenericRepository<FarmSite> FarmSites => _farmSites ??= new GenericRepository<FarmSite>(_context);
    public IGenericRepository<FarmField> FarmFields => _farmFields ??= new GenericRepository<FarmField>(_context);
    public IGenericRepository<Crop> Crops => _crops ??= new GenericRepository<Crop>(_context);
    public IGenericRepository<WorkTaskType> WorkTaskTypes => _workTaskTypes ??= new GenericRepository<WorkTaskType>(_context);
    public IGenericRepository<WorkTask> WorkTasks => _workTasks ??= new GenericRepository<WorkTask>(_context);

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
