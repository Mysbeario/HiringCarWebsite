using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.CustomerAggregate;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class CustomerAccountRepository: IGenericRepository<CustomerAccount> {
        private ApplicationContext _context;

        public CustomerAccountRepository (ApplicationContext context) {
            this._context = context;
        }

        public async Task<IEnumerable<CustomerAccount>> GetAll () {
            return await _context.CustomerAccount.ToListAsync ();
        }

        public async Task<IEnumerable<CustomerAccount>> GetPaginated (int page, int size, string sortBy, string search) {
            var list = await Search (search);
            switch (sortBy) {
                //...
                default:
                    list = list.OrderBy (a => a.Id);
                    break;
            }
            return list.Skip ((page - 1) * size).Take (size);
        }

        public async Task<CustomerAccount> GetById (string id) {
            return await _context.CustomerAccount.FindAsync (id);
        }

        public async Task Create (CustomerAccount entity) {
            await _context.CustomerAccount.AddAsync (entity);
            await _context.SaveChangesAsync ();
        }

        public async Task Update (CustomerAccount entity) {
            _context.Entry (entity).State = EntityState.Modified;
            await _context.SaveChangesAsync ();
        }
        public async Task Delete (string id) {
            CustomerAccount customerAccount = await _context.CustomerAccount.FindAsync (id);
            _context.CustomerAccount.Remove (customerAccount);
            await _context.SaveChangesAsync ();
        }

        public async Task<int> CountPages (int size, string search) {
            int amount = (await Search (search)).Count ();
            return (int) Math.Ceiling (amount / (double) size);
        }

        public async Task<IEnumerable<CustomerAccount>> Search (string s) {
            var list = await GetAll ();
            if (s.Trim () != "") {
                //list = list.Where (e => EF.Functions.Like(e.NumberPlate, $"%{s}%"));
            }
            return list;
        }
    }
}