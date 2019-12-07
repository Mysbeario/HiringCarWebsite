using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers {
    [ApiController]
    [Route ("/api/cartype")]
    public class CarTypeController : ControllerBase {
        private GenericRepository<CarType> carTypeRepository;

        public CarTypeController () {
            this.carTypeRepository = new GenericRepository<CarType> (new ApplicationContext ());
        }

        [HttpGet]
        [Route ("~/api/pagination/cartype")]
        public async Task<int> CountPages ([FromQuery] int size, [FromQuery] string search = " ") {
            ISpecification<CarType> carTypeExpSpec =
                new ExpressionSpecification<CarType> (e => EF.Functions.Like (e.Name, $"%{search.Trim()}%"));
            return await carTypeRepository.CountPages (size, carTypeExpSpec);
        }

        [HttpGet]
        [Route ("~/api/pagination/cartype/{page}")]
        public async Task<IEnumerable<CarType>> GetPaginated (int page, [FromQuery] int size, [FromQuery] string sortBy, [FromQuery] string search = " ") {
            ISpecification<CarType> carTypeExpSpec =
                new ExpressionSpecification<CarType> (e => EF.Functions.Like (e.Name, $"%{search.Trim()}%"));
            var list = await carTypeRepository.Search (carTypeExpSpec);
            Func<CarType, object> orderFunc = a => a.Id;

            switch (sortBy) {
                case "name":
                    orderFunc = a => a.Name;
                    break;
                case "seat":
                    orderFunc = a => a.Seat;
                    break;
                case "cost":
                    orderFunc = a => a.Cost;
                    break;
            }

            return list.OrderBy (orderFunc).Skip ((page - 1) * size).Take (size);
        }

        [HttpGet]
        public async Task<IEnumerable<CarType>> GetAll () {
            return await carTypeRepository.GetAll ();
        }

        [HttpPost]
        public async Task Create ([FromForm] CarType carType) {
            await carTypeRepository.Create (new CarType {
                Name = carType.Name,
                    Cost = carType.Cost,
                    Seat = carType.Seat
            });
        }

        [HttpGet]
        [Route ("{id}")]
        public async Task<CarType> GetByID (int id) {
            Console.WriteLine ("{id}");
            return await carTypeRepository.GetById (id);
        }

        [HttpPut]
        [Route ("{id}")]
        public async Task Update ([FromForm] CarType carType) {
            await carTypeRepository.Update (carType);
        }

        [HttpDelete]
        [Route ("{id}")]
        public async Task Delete (int id) {
            await carTypeRepository.Delete (id);
        }
    }
}