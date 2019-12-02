using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers {
	[ApiController]
	[Route ("/api/car")]
	public class CarController : ControllerBase {
		private CarRepository carRepository;
		private CarTypeRepository carTypeRepository;
		private readonly IMapper mapper;

		public CarController (IMapper mapper) {
			this.carRepository = new CarRepository (new ApplicationContext ());
			this.carTypeRepository = new CarTypeRepository (new ApplicationContext ());
			this.mapper = mapper;
		}

		[HttpGet]
		[Route ("~/api/pagination/car")]
		public async Task<int> CountPages ([FromQuery] int size, [FromQuery] string search = " ") {
			return await carRepository.CountPages (size, search);
		}

		[HttpGet]
		[Route ("~/api/pagination/car/{page}")]
		public async Task<IEnumerable<CarDTO>> GetPaginated (int page, [FromQuery] int size, [FromQuery] string sortBy, [FromQuery] string search = " ") {
			var carList = await carRepository.GetPaginated (page, size, sortBy, search);
			var carTypeList = await carTypeRepository.GetAll ();
			List<CarDTO> carDTOList = new List<CarDTO> ();

			foreach (var car in carList) {
				var carTypeName = carTypeList.Where (ct => ct.Id == car.CarTypeId).First ().Name;
				CarDTO carDTO = mapper.Map<CarDTO> (car);
				carDTO.CarTypeName = carTypeName;
				carDTOList.Add (carDTO);
			}

			return carDTOList;
		}

		[HttpGet]
		public async Task<IEnumerable<Car>> GetAll () {
			return await carRepository.GetAll ();
		}

		[HttpPost]
		public async Task Create ([FromForm] Car car) {
			await carRepository.Create (car);
		}

		[HttpGet]
		[Route ("{id}")]
		public async Task<Car> GetByID (string id) {
			Console.WriteLine ("{id}");
			return await carRepository.GetById (id);
		}

		[HttpPut]
		[Route ("{id}")]
		public async Task Update ([FromForm] Car car) {
			await carRepository.Update (car);
		}

		[HttpDelete]
		[Route ("{id}")]
		public async Task Delete (string id) {
			await carRepository.Delete (id);
		}
	}
}