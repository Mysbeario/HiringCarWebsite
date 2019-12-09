using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers {
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route ("/api/user/register")]
        public async Task<IActionResult> Register ([FromForm] RegisterVM model) {
            if (ModelState.IsValid) {
                var user = new IdentityUser {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync (user, model.Password);

                if (result.Succeeded) {
                    await signInManager.SignInAsync (user, isPersistent : false);
                    return Ok ();
                }

                return BadRequest (result.Errors);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route ("/api/user/login")]
        public async Task Login ([FromForm] LoginVM model) {
            await signInManager.PasswordSignInAsync (model.Email, model.Password, false, false);
        }
    }
}