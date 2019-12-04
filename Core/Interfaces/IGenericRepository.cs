using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces {
    public interface IGenericRepository<T> where T : BaseEntity {
        Task<IEnumerable<T>> GetAll ();
        Task<IEnumerable<T>> GetPaginated (int page, int size, ISpecification<T> spec);
        Task<T> GetById (int id);
        Task Create (T entity);
        Task Update (T entity);
        Task Delete (int id);
        Task<IEnumerable<T>> Search (ISpecification<T> spec);
        Task<IEnumerable<T>> OrderBy (ISpecification<T> sortBy);
    }
}