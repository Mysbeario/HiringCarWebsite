using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.Entities.CustomerAggregate;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers {
    [ApiController]
    [Route ("/api/customer")]
    public class CustomerController : ControllerBase {
        private GenericRepository<CustomerAccount> customerRepository;

        public CustomerController () {
            this.customerRepository = new GenericRepository<CustomerAccount> (new ApplicationContext ());
        }

        [HttpPost]
        public async Task Create ([FromForm] CustomerAccount account,[FromForm] CustomerDetail profile) {
            CustomerAccount customer = new CustomerAccount {
                Email = account.Email,
                Password = account.Password
            };

            CustomerDetail customerProfile = new CustomerDetail {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                PhoneNumber = profile.PhoneNumber,
                CustomerAccountId = customer.Id
            };

            customer.CreateProfile (customerProfile);
            await this.customerRepository.Create (customer);
        }
    }
}