using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Controllers {
    [ApiController]
    [Route ("/api/cartype")]
    public class CarTypeController : ControllerBase {
        private CarTypeRepository carTypeRepository;

        public CarTypeController () {
            this.carTypeRepository = new CarTypeRepository (new ApplicationContext ());
        }

        [HttpGet]
        [Route ("~/api/pagination/cartype")]
        public async Task<int> CountPages ([FromQuery]int size) {
            return await carTypeRepository.CountPages (size);
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
            Console.WriteLine("{id}");
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