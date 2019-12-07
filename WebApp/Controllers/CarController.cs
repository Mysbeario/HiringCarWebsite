using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers {
	[ApiController]
	[Route ("/api/car")]
	public class CarController : ControllerBase {
		private CarRepository carRepository;
		private GenericRepository<CarType> carTypeRepository;
		private readonly IMapper mapper;

		public CarController (IMapper mapper) {
			this.carRepository = new CarRepository (new ApplicationContext ());
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
			var list = await carRepository.Search(carExpSpec);
			Func<CarDTO, object> orderFunc = a => a.Id; 
			switch (sortBy) {
				case "numberPlate":
					orderFunc = a => a.NumberPlate;
					break;
				case "color":
					orderFunc = a => a.Color;
					break;
				case "carTypeName":
					orderFunc = a => a.CarTypeName;
					break;
			}

			var carTypeList = await carTypeRepository.GetAll ();
			List<CarDTO> carDTOList = new List<CarDTO> ();

			foreach (var car in list) {
				var carType = carTypeList.Where (ct => ct.Id == car.CarTypeId).First ();
				CarDTO carDTO = mapper.Map<Car, CarDTO> (car);
				mapper.Map<CarType, CarDTO> (carType, carDTO);
				carDTOList.Add (carDTO);
			}

			return carDTOList.OrderBy(orderFunc).Skip((page - 1) * size).Take(size);
		}

		[HttpGet]
		public async Task<IEnumerable<Car>> GetAll () {
			return await carRepository.GetAll ();
		}

		[HttpPost]
		public async Task Create ([FromForm] Car car, [FromForm] IFormFile image) {
			byte[] file;
			using (var memoryStream = new MemoryStream ()) {
				await image.CopyToAsync (memoryStream);
				file = memoryStream.ToArray ();
			}

			var name = $"img_{car.NumberPlate.Replace(" ", "").Replace("-", "_")}";
			car.ImgPath = name;

			await carRepository.UploadImage (file, name);
			await carRepository.Create (car);
		}

		[HttpGet]
		[Route ("{id}")]
		public async Task<Car> GetByID (int id) {
			return await carRepository.GetById (id);
		}

		[HttpPut]
		[Route ("{id}")]
		public async Task Update ([FromForm] Car car, [FromForm] IFormFile image) {
			if (image != null) {
				byte[] file;
				using (var memoryStream = new MemoryStream ()) {
					await image.CopyToAsync (memoryStream);
					file = memoryStream.ToArray ();
				}

				var name = $"img_{car.NumberPlate.Replace(" ", "").Replace("-", "_")}";
				car.ImgPath = name;

				await carRepository.UploadImage (file, name);
			}
			await carRepository.Update (car);
		}

		[HttpDelete]
		[Route ("{id}")]
		public async Task Delete (int id) {
			await carRepository.Delete (id);
		}
	}
}