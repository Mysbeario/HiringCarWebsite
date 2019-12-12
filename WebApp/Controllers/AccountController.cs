using System.Collections.Generic;
using System.Linq;
using Core.ValueObjects;
using Core.Interfaces;
using Core.Specification;
using Core.Entities;
using Core.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Model;
using System;

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

        [HttpGet]
        [Route ("~/api/pagination/user/{page}")]
        public ActionResult<PageData<User>> GetPaginated(int page, [FromQuery] PaginateQuery query ) {
            PageData<User> result = new PageData<User> ();
            Func<User, object> orderFunc = a => a.Id;

            var list = userManager.Users.ToList();

            result.TotalPages = (int) Math.Ceiling (list.Count () / (double) query.PageSize);

            switch (query.SortBy) {
                case "email":
                    orderFunc = a => a.Email;
                    break;
            }

            if (!query.Desc) {
                result.List = list.OrderBy (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
            } else {
                result.List = list.OrderByDescending (orderFunc).Skip ((page - 1) * query.PageSize).Take (query.PageSize);
            }

            return result;
        }

        [HttpDelete]
        [Route("/api/user/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(string id) {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return Ok();
        }
    }
}