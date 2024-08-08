using MCPlaces_Backend.Models;
using System.Linq.Expressions;

namespace MCPlaces_Backend.Repository.GenericRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
