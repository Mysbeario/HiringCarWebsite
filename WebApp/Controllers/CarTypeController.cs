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
        public async Task<IEnumerable<CarType>> Get () {
            return await carTypeRepository.GetAll ();
        }
    }
}