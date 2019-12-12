using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Core.ValueObjects;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
        [Route ("~/api/pagination/cartype/{page}")]
        public async Task<PageData<CarType>> GetPaginated (int page, [FromQuery] PaginateQuery query) {
            ISpecification<CarType> carTypeExpSpec =
                new ExpressionSpecification<CarType> (e => EF.Functions.Like (e.Name, $"%{query.Search.Trim()}%"));
            Func<CarType, object> orderFunc = a => a.Id;
            PageData<CarType> result = new PageData<CarType> ();

            var list = await carTypeRepository.Search (carTypeExpSpec);

            result.TotalPages = (int) Math.Ceiling (list.Count () / (double) query.PageSize);

            switch (query.SortBy) {
                case "name":
                    orderFunc = a => a.Name;
                    break;
                case "seat":
                    orderFunc = a => a.Seat;
                    break;
                case "cost":
                    orderFunc = a => a.Cost;
                    break;
            }

            if (!query.Desc) {
                result.List = list.OrderBy (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
            } else {
                result.List = list.OrderByDescending (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
            }

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<CarType>> GetAll () {
            return await carTypeRepository.GetAll ();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create ([FromForm] CarType carType) {
            if (ModelState.IsValid) {
                await carTypeRepository.Create (carType);
                return Ok ();
            }
            
            var allErrors = ModelState.Values.SelectMany (v => v.Errors.Select (b => b.ErrorMessage));
            return BadRequest (allErrors);
        }

        [HttpGet]
        [Route ("{id}")]
        public async Task<CarType> GetByID (int id) {
            Console.WriteLine ("{id}");
            return await carTypeRepository.GetById (id);
        }

        [HttpPut]
        [Route ("{id}")]
        [Authorize]
        public async Task<IActionResult> Update ([FromForm] CarType carType) {
            if (ModelState.IsValid) {
                await carTypeRepository.Update (carType);
                return Ok();
            }

            var allErrors = ModelState.Values.SelectMany (v => v.Errors.Select (b => b.ErrorMessage));
            return BadRequest (allErrors);
        }

        [HttpDelete]
        [Route ("{id}")]
        [Authorize]
        public async Task Delete (int id) {
            await carTypeRepository.Delete (id);
        }
    }
}