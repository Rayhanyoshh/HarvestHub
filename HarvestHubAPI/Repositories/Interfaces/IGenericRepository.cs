namespace HarvestHubAPI.Repositories.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();

    IQueryable<T> AsQueryable(); // Tambahkan metode ini
    Task<T> GetById(object id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(object id);
}
