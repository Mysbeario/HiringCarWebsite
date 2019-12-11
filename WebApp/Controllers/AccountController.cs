using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;

namespace WebApp.Controllers {
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController (UserManager<User> userManager, SignInManager<User> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        private async Task SetCookie (string email) {
            var userId = (await userManager.FindByEmailAsync (email)).Id;
            Response.Cookies.Append ("User.ID", userId);
        }

        [HttpGet]
        [Authorize]
        [Route ("/api/user/auth")]
        public async Task<ActionResult> Auth () {
            try {
                var user = await userManager.FindByIdAsync (Request.Cookies["User.Id"]);
                return Ok ();
            } catch {
                return Unauthorized ();
            }
        }

        [HttpPost]
        [Authorize]
        [Route ("/api/user/logout")]
        public async Task<ActionResult> LogOut () {
            await signInManager.SignOutAsync ();
            return Ok ();
        }

        [HttpPost]
        [Route ("/api/user/register")]
        public async Task<IActionResult> Register ([FromForm] RegisterVM model) {
            if (ModelState.IsValid) {
                var user = new User {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync (user, model.Password);

                if (result.Succeeded) {
                    await signInManager.SignInAsync (user, isPersistent : false);
                    await SetCookie (model.Email);
                    return Ok ();
                }

                return BadRequest (result.Errors);
            }

            return BadRequest ();
        }

        [HttpPost]
        [Route ("/api/user/login")]
        public async Task<ActionResult> Login ([FromForm] LoginVM model) {
            if (ModelState.IsValid) {
                var result = await signInManager.PasswordSignInAsync (model.Email, model.Password, false, false);

                if (result.Succeeded) {
                    await SetCookie (model.Email);
                    return Ok ();
                }

                return Unauthorized ();
            }

            return BadRequest ();
        }
    }
}