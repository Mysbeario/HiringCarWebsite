using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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
            var list = await GetAll();
            return list.OrderBy(a => a.Id).Skip((page - 1) * size).Take(size);
        }

        public async Task<CarType> GetById (string id) {
            return await _context.CarType.FindAsync(id);
        }

        public async Task Create (CarType entity) {
            await _context.CarType.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update (CarType entity) {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete (string id) {
            CarType carType = await _context.CarType.FindAsync(id);
            _context.CarType.Remove(carType);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountPages (int size) {
            int amount = await _context.CarType.CountAsync();
            return (int)Math.Ceiling(amount / (double)size);
        }
    }
}