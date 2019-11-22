using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class CarTypeController : ControllerBase {
        private CarTypeRepository carTypeRepository;

        public CarTypeController () {
            this.carTypeRepository = new CarTypeRepository (new ApplicationContext ());
        }

        [HttpGet]
        [Route("/api/cartype")]
        public async Task<IEnumerable<CarType>> GetAll () {
            return await carTypeRepository.GetAll ();
        }

        [HttpPost]
        [Route("/api/cartype")]
        public async Task Create ([FromForm] CarType carType) {
            await carTypeRepository.Create(carType);
        }

        [HttpGet]
        [Route("/api/cartype/{id}")]
        public async Task<CarType> GetByID (string id) {
            return await carTypeRepository.GetById(id);
        }
    }
}