using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class CarTypeRepository : IGenericRepository<CarType> {
        private ApplicationContext _context;

        public CarTypeRepository (ApplicationContext context) {
            this._context = context;
        }

        public async Task<IEnumerable<CarType>> GetAll () {
            return await _context.CarType.ToListAsync ();
        }

        public async Task<IEnumerable<CarType>> GetPaginated (int page, int size) {
            return null;
        }

        public async Task<CarType> GetById (string id) {
            return null;
        }

        public async Task Create (CarType entity) {

        }
        public async Task Update (string id, CarType entity) {

        }
        public async Task Delete (string id) {

        }
    }
}