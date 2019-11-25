using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CarType>> GetPaginated (int page, int size, string sortBy, string search) {
            var list = await Search (search);
            switch (sortBy) {
                case "name":
                    list = list.OrderBy (a => a.Name);
                    break;
                case "seat":
                    list = list.OrderBy (a => a.Seat);
                    break;
                case "cost":
                    list = list.OrderBy (a => a.Cost);
                    break;
                default:
                    list = list.OrderBy (a => a.Id);
                    break;
            }
            return list.Skip ((page - 1) * size).Take (size);
        }

        public async Task<CarType> GetById (string id) {
            return await _context.CarType.FindAsync (id);
        }

        public async Task Create (CarType entity) {
            await _context.CarType.AddAsync (entity);
            await _context.SaveChangesAsync ();
        }

        public async Task Update (CarType entity) {
            _context.Entry (entity).State = EntityState.Modified;
            await _context.SaveChangesAsync ();
        }
        public async Task Delete (string id) {
            CarType carType = await _context.CarType.FindAsync (id);
            _context.CarType.Remove (carType);
            await _context.SaveChangesAsync ();
        }

        public async Task<int> CountPages (int size, string search) {
            int amount = (await Search (search)).Count ();
            return (int) Math.Ceiling (amount / (double) size);
        }

        public async Task<IEnumerable<CarType>> Search (string s) {
            var list = await GetAll ();
            if (s.Trim () != "") {
                list = list.Where (e => EF.Functions.Like(e.Name, $"%{s}%"));
            }
            return list;
        }
    }
}