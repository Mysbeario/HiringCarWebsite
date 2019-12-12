using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Core.ValueObjects;
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
		private GenericRepository<Booking> bookingRepository;
		private readonly IMapper mapper;

		public CarController (IMapper mapper) {
			this.carRepository = new CarRepository (new ApplicationContext ());
			this.carTypeRepository = new GenericRepository<CarType> (new ApplicationContext ());
			this.bookingRepository = new GenericRepository<Booking> (new ApplicationContext ());
			this.mapper = mapper;
		}

		[HttpGet]
		[Route ("~/api/pagination/car")]
		public async Task<int> CountPages ([FromQuery] CarQuery query) {
			ISpecification<Car> numberPlateFilter =
				new ExpressionSpecification<Car> (e => EF.Functions.Like (e.NumberPlate, $"%{query.Search.Trim()}%"));
			ISpecification<Car> carTypeFilter = new ExpressionSpecification<Car> (e => query.CarTypeId == 0 ? true : e.CarTypeId == query.CarTypeId);
			ISpecification<Car> carExpSpec = numberPlateFilter.And (carTypeFilter);
			return await carRepository.CountPages (query.PageSize, carExpSpec);
		}

		private async Task<IEnumerable<CarDTO>> Filter (CarQuery query) {
			ISpecification<Car> numberPlateFilter =
				new ExpressionSpecification<Car> (e => EF.Functions.Like (e.NumberPlate, $"%{query.Search.Trim()}%"));
			ISpecification<Car> carTypeFilter = new ExpressionSpecification<Car> (e => query.CarTypeId == 0 ? true : e.CarTypeId == query.CarTypeId);
			ISpecification<CarDTO> seatFilter = new ExpressionSpecification<CarDTO> (c => query.Seat == 0 ? true : c.Seat == query.Seat);
			ISpecification<CarDTO> priceFilter = new ExpressionSpecification<CarDTO> (e => query.MaxPrice == 0 ? true : e.Cost >= query.MinPrice && e.Cost <= query.MaxPrice);
			var startDay = DateTime.ParseExact (query.PickUpDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			var endDay = DateTime.ParseExact (query.DropOffDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			ISpecification<Booking> dateFilter = new ExpressionSpecification<Booking> (e =>
				(DateTime.Compare (startDay, e.PickUpDate) <= 0 && DateTime.Compare (endDay, e.PickUpDate) >= 0) ||
				(DateTime.Compare (startDay, e.DropOffDate) <= 0 && DateTime.Compare (endDay, e.DropOffDate) >= 0));
			ISpecification<CarDTO> carDTOExpSpec = seatFilter.And (priceFilter);
			ISpecification<Car> carExpSpec = numberPlateFilter.And (carTypeFilter);

			var list = await carRepository.Search (carExpSpec);

			var carTypeList = await carTypeRepository.GetAll ();
			var bookingList = await bookingRepository.Search (dateFilter);
			List<CarDTO> carDTOList = new List<CarDTO> ();

			foreach (var car in list) {
				if (bookingList.Where (e => e.CarId == car.Id).Count () == 0) {
					var carType = await carTypeRepository.GetById (car.CarTypeId);
					CarDTO carDTO = mapper.Map<Car, CarDTO> (car);
					mapper.Map<CarType, CarDTO> (carType, carDTO);
					carDTOList.Add (carDTO);
				}
			}

			return carDTOList.Where (c => carDTOExpSpec.IsSatisfiedBy (c)).ToList ();
		}

		[HttpGet]
		[Route ("~/api/pagination/car/{page}")]
		public async Task<PageData<CarDTO>> GetPaginated (int page, [FromQuery] CarQuery query) {
			PageData<CarDTO> result = new PageData<CarDTO> ();
			var carDTOList = await Filter (query);

			Func<CarDTO, object> orderFunc = a => a.Id;
			switch (query.SortBy) {
				case "numberPlate":
					orderFunc = a => a.NumberPlate;
					break;
				case "color":
					orderFunc = a => a.Color;
					break;
				case "carTypeName":
					orderFunc = a => a.CarTypeName;
					break;
				case "cost":
					orderFunc = a => a.Cost;
					break;
				case "seat":
					orderFunc = a => a.Seat;
					break;
			}

			result.TotalPages = (int) Math.Ceiling (carDTOList.Count () / (double) query.PageSize);

			if (!query.Desc) {
				result.List = carDTOList.OrderBy (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
			} else {
				result.List = carDTOList.OrderByDescending (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
			}

			return result;
		}

		[HttpGet]
		public async Task<IEnumerable<Car>> GetAll () {
			return await carRepository.GetAll ();
		}

		[HttpPost]
		public async Task<IActionResult> Create ([FromForm] Car car, [FromForm] IFormFile image) {
			byte[] file;
			using (var memoryStream = new MemoryStream ()) {
				await image.CopyToAsync (memoryStream);
				file = memoryStream.ToArray ();
			}

			var name = $"img_{car.NumberPlate.Replace(" ", "").Replace("-", "_")}";
			car.ImgPath = name;

			if (ModelState.IsValid) {
				await carRepository.UploadImage (file, name);
				await carRepository.Create (car);
				return Ok ();
			}

			var allErrors = ModelState.Values.SelectMany (v => v.Errors.Select (b => b.ErrorMessage));
			return BadRequest (allErrors);
		}

		[HttpGet]
		[Route ("{id}")]
		public async Task<CarDTO> GetByID (int id) {
			var car = await carRepository.GetById (id);
			var carType = await carTypeRepository.GetById (car.CarTypeId);
			CarDTO carDTO = mapper.Map<Car, CarDTO> (car);
			mapper.Map<CarType, CarDTO> (carType, carDTO);
			return carDTO;
		}

		[HttpPut]
		[Route ("{id}")]
		public async Task<IActionResult> Update ([FromForm] Car car, [FromForm] IFormFile image) {
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

			if (ModelState.IsValid) {
				await carRepository.Update (car);
				return Ok ();
			}

			var allErrors = ModelState.Values.SelectMany (v => v.Errors.Select (b => b.ErrorMessage));
			return BadRequest (allErrors);
		}

		[HttpDelete]
		[Route ("{id}")]
		public async Task Delete (int id) {
			await carRepository.Delete (id);
		}
	}
}