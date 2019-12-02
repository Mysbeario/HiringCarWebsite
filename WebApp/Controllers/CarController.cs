using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers {
	[ApiController]
	[Route ("/api/car")]
	public class CarController : ControllerBase {
		private GenericRepository<Car> carRepository;
		private GenericRepository<CarType> carTypeRepository;
		private readonly IMapper mapper;

		public CarController (IMapper mapper) {
			this.carRepository = new GenericRepository<Car> (new ApplicationContext ());
			this.carTypeRepository = new GenericRepository<CarType> (new ApplicationContext ());
			this.mapper = mapper;
		}

		[HttpGet]
		[Route ("~/api/pagination/car")]
		public async Task<int> CountPages ([FromQuery] int size, [FromQuery] string search = " ") {
			ISpecification<Car> carExpSpec =
				new ExpressionSpecification<Car> (e => EF.Functions.Like (e.NumberPlate, $"%{search.Trim()}%"));
			return await carRepository.CountPages (size, carExpSpec);
		}

		[HttpGet]
		[Route ("~/api/pagination/car/{page}")]
		public async Task<IEnumerable<CarDTO>> GetPaginated (int page, [FromQuery] int size, [FromQuery] string sortBy, [FromQuery] string search = " ") {
			ISpecification<Car> carExpSpec =
				new ExpressionSpecification<Car> (e => EF.Functions.Like (e.NumberPlate, $"%{search.Trim()}%"));
			switch (sortBy) {
				case "numberPlate":
					carExpSpec.orderExpression = a => a.NumberPlate;
					break;
				case "color":
					carExpSpec.orderExpression = a => a.Color;
					break;
				case "carTypeId":
					carExpSpec.orderExpression = a => a.CarTypeId;
					break;
				default:
					carExpSpec.orderExpression = a => a.Id;
					break;
			}
			var carList = await carRepository.GetPaginated (page, size, carExpSpec);
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