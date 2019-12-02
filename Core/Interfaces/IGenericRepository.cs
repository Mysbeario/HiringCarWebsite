using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces {
    public interface IGenericRepository<T> where T : BaseEntity {
        Task<IEnumerable<T>> GetAll ();
        Task<IEnumerable<T>> GetPaginated (int page, int size, string sortBy, string name);
        Task<T> GetById (string id);
        Task Create (T entity);
        Task Update (T entity);
        Task Delete (string id);
        Task<IEnumerable<T>> Search (string name);
        Task<IEnumerable<T>> SortBy (string sortBy);
    }
}