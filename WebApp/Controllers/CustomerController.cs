using System.Threading.Tasks;
using Core.Entities.CustomerAggregate;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers {
    [ApiController]
    [Route ("/api/customer")]
    public class CustomerController : ControllerBase {
        private CustomerAccountRepository customerRepository;
        public CustomerController () {
            this.customerRepository = new CustomerAccountRepository (new ApplicationContext ());
        }

        [HttpPost]
        public async Task Create ([FromForm] CustomerAccount account) {
            await customerRepository.Create (account);
        }
    }
}