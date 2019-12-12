using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers {
    [ApiController]
    [Route ("/api/booking")]
    public class BookingController : ControllerBase {
        private GenericRepository<Booking> bookingRepository;
        private GenericRepository<CarType> carTypeRepository;
        private GenericRepository<Car> carRepository;
        private UserManager<User> userManager;
        private readonly IMapper mapper;

        public BookingController (IMapper mapper, UserManager<User> userManager) {
            this.bookingRepository = new GenericRepository<Booking> (new ApplicationContext ());
            this.carTypeRepository = new GenericRepository<CarType> (new ApplicationContext ());
            this.carRepository = new GenericRepository<Car> (new ApplicationContext ());
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create ([FromForm] BookingVM bookingInfo) {
            if (ModelState.IsValid) {
                var startDay = DateTime.ParseExact (bookingInfo.PickUpDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var endDay = DateTime.ParseExact (bookingInfo.DropOffDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                ISpecification<Booking> dateFilter = new ExpressionSpecification<Booking> (e =>
                    (DateTime.Compare (startDay, e.PickUpDate) <= 0 && DateTime.Compare (endDay, e.PickUpDate) >= 0) ||
                    (DateTime.Compare (startDay, e.DropOffDate) <= 0 && DateTime.Compare (endDay, e.DropOffDate) >= 0));
                var bookingList = await bookingRepository.Search (dateFilter);

                if (bookingList.Where (e => e.CarId == bookingInfo.CarId).Count () == 0) {
                    var totalDays = (endDay - startDay).TotalDays + 1;
                    var cost = (await carTypeRepository.GetById ((await carRepository.GetById (bookingInfo.CarId)).CarTypeId)).Cost;

                    Booking booking = new Booking {
                        CarId = bookingInfo.CarId,
                        UserId = Request.Cookies["User.ID"],
                        PickUpLocation = bookingInfo.PickUpLocation,
                        DropOffLocation = bookingInfo.DropOffLocation,
                        PickUpDate = startDay,
                        DropOffDate = endDay,
                        TotalCost = (decimal) totalDays * cost,
                        Status = "Pending"
                    };

                    await bookingRepository.Create (booking);
                    return Ok ();
                }
            }
            return BadRequest ();
        }

        [HttpGet]
        [Route ("~/api/pagination/booking/{page}")]
        public async Task<PageData<BookingDTO>> GetPaginated (int page, [FromQuery] PaginateQuery query) {
            Func<BookingDTO, object> orderFunc = a => a.Id;
            PageData<BookingDTO> result = new PageData<BookingDTO> ();

            List<BookingDTO> bookingDTOList = new List<BookingDTO> ();
            var bookingList = await bookingRepository.GetAll ();

            foreach (var booking in bookingList) {
                var numberPlate = (await carRepository.GetById (booking.CarId)).NumberPlate;
                var userEmail = (await userManager.FindByIdAsync (booking.UserId)).Email;

                var bookingDTO = mapper.Map<Booking, BookingDTO> (booking);
                bookingDTO.UserEmail = userEmail;
                bookingDTO.NumberPlate = numberPlate;

                bookingDTOList.Add (bookingDTO);
            }

            result.TotalPages = (int) Math.Ceiling (bookingDTOList.Count () / (double) query.PageSize);

            switch (query.SortBy) {
                case "totalCost":
                    orderFunc = a => a.TotalCost;
                    break;
                case "date":
                    orderFunc = a => a.PickUpDate;
                    break;
            }

            if (!query.Desc) {
                result.List = bookingDTOList.OrderBy (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
            } else {
                result.List = bookingDTOList.OrderByDescending (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
            }

            return result;
        }

        [HttpPut]
        [Route ("~/api/status/booking/{id}")]
        [Authorize]
        public async Task<IActionResult> Cancel (int id, [FromQuery] String Action) {
            var booking = await bookingRepository.GetById (id);
            if (Action == "cancel") {
                booking.Status = "Cancel";
            } else if (Action == "paid") {
                booking.Status = "Paid";
            }

            await bookingRepository.Update (booking);
            return Ok ();
        }

        [HttpPut]
        [Route ("{id}")]
        [Authorize]
        public async Task<IActionResult> Update ([FromForm] BookingVM bookingInfo) {
            if (ModelState.IsValid) {
                var startDay = DateTime.ParseExact (bookingInfo.PickUpDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var endDay = DateTime.ParseExact (bookingInfo.DropOffDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var totalDays = (endDay - startDay).TotalDays + 1;
                var cost = (await carTypeRepository.GetById ((await carRepository.GetById (bookingInfo.CarId)).CarTypeId)).Cost;

                Booking booking = new Booking {
                    Id = bookingInfo.Id,
                    CarId = bookingInfo.CarId,
                    UserId = bookingInfo.UserId,
                    PickUpDate = startDay,
                    DropOffDate = endDay,
                    PickUpLocation = bookingInfo.PickUpLocation,
                    DropOffLocation = bookingInfo.DropOffLocation,
                    TotalCost = cost,
                    Status = bookingInfo.Status
                };

                await bookingRepository.Update (booking);
                return Ok ();
            }

            var allErrors = ModelState.Values.SelectMany (v => v.Errors.Select (b => b.ErrorMessage));
            return BadRequest (allErrors);
        }
    }
}