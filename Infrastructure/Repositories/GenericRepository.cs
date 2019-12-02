using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
		protected readonly ApplicationContext _context;
		public GenericRepository (ApplicationContext context) {
			this._context = context;
		}
		public async Task<IEnumerable<T>> GetAll () {
			return await _context.Set<T> ().ToListAsync ();
		}
		public async Task<IEnumerable<T>> GetPaginated (int page, int size, ISpecification<T> spec) {
			return (await OrderBy (spec)).Skip ((page - 1) * size).Take (size);
		}
		public async Task<T> GetById (string id) {
			return await _context.Set<T> ().FindAsync (id);
		}
		public async Task Create (T entity) {
			await _context.Set<T> ().AddAsync (entity);
			await _context.SaveChangesAsync ();
		}
		public async Task Update (T entity) {
			_context.Entry (entity).State = EntityState.Modified;
			await _context.SaveChangesAsync ();
		}
		public async Task Delete (string id) {
			var target = await _context.Set<T> ().FindAsync (id);
			_context.Set<T> ().Remove (target);
			await _context.SaveChangesAsync ();
		}
		public async Task<IEnumerable<T>> Search (ISpecification<T> spec) {
			return (await GetAll ()).Where (e => spec.IsSatisfiedBy (e));
		}
		public async Task<IEnumerable<T>> OrderBy (ISpecification<T> spec) {
			return (await Search (spec)).OrderBy (spec.orderExpression);
		}

		public async Task<int> CountPages (int size, ISpecification<T> spec) {
			return (int) Math.Ceiling ((await Search (spec)).Count () / (double) size);
		}
	}
}