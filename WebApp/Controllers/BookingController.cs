using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers {
    [ApiController]
    public class BookingController : ControllerBase {
        private GenericRepository<Booking> bookingRepository;
        private GenericRepository<CarType> carTypeRepository;
        private GenericRepository<Car> carRepository;

        public BookingController () {
            this.bookingRepository = new GenericRepository<Booking> (new ApplicationContext ());
            this.carTypeRepository = new GenericRepository<CarType> (new ApplicationContext ());
            this.carRepository = new GenericRepository<Car> (new ApplicationContext ());
        }

        [HttpPost]
        [Route ("/api/booking")]
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
    }
}