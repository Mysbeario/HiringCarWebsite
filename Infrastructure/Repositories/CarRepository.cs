using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class CarRepository {
        private ApplicationContext _context;

        public CarRepository (ApplicationContext context) {
            this._context = context;
        }

        public async Task<IEnumerable<Car>> GetAll () {
            return await _context.Car.ToListAsync ();
        }

        public async Task<IEnumerable<Car>> GetPaginated (int page, int size, string sortBy, string search) {
            var list = await Search (search);
            switch (sortBy) {
                case "numberPlate":
                    list = list.OrderBy (a => a.NumberPlate);
                    break;
                case "color":
                    list = list.OrderBy (a => a.Color);
                    break;
                default:
                    list = list.OrderBy (a => a.Id);
                    break;
            }
            return list.Skip ((page - 1) * size).Take (size);
        }

        public async Task<Car> GetById (string id) {
            return await _context.Car.FindAsync (id);
        }

        public async Task Create (Car entity) {
            await _context.Car.AddAsync (entity);
            await _context.SaveChangesAsync ();
        }

        public async Task Update (Car entity) {
            _context.Entry (entity).State = EntityState.Modified;
            await _context.SaveChangesAsync ();
        }
        public async Task Delete (string id) {
            Car car = await _context.Car.FindAsync (id);
            _context.Car.Remove (car);
            await _context.SaveChangesAsync ();
        }

        public async Task<int> CountPages (int size, string search) {
            int amount = (await Search (search)).Count ();
            return (int) Math.Ceiling (amount / (double) size);
        }

        public async Task<IEnumerable<Car>> Search (string s) {
            var list = await GetAll ();
            if (s.Trim () != "") {
                list = list.Where (e => EF.Functions.Like(e.NumberPlate, $"%{s}%"));
            }
            return list;
        }
    }
}