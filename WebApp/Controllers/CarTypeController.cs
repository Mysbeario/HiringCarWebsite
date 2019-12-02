using System;
using System.Collections.Generic;
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
            switch (sortBy) {
                case "name":
                    carTypeExpSpec.orderExpression = a => a.Name;
                    break;
                case "seat":
                    carTypeExpSpec.orderExpression = a => a.Seat;
                    break;
                case "cost":
                    carTypeExpSpec.orderExpression = a => a.Cost;
                    break;
                default:
                    carTypeExpSpec.orderExpression = a => a.Id;
                    break;
            }
            return await carTypeRepository.GetPaginated (page, size, carTypeExpSpec);
        }

        [HttpGet]
        public async Task<IEnumerable<CarType>> GetAll () {
            return await carTypeRepository.GetAll ();
        }

        [HttpPost]
        public async Task Create ([FromForm] CarType carType) {
            await carTypeRepository.Create (carType);
        }

        [HttpGet]
        [Route ("{id}")]
        public async Task<CarType> GetByID (string id) {
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
        public async Task Delete (string id) {
            await carTypeRepository.Delete (id);
        }
    }
}