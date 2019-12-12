using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Controllers
{
    public class AdministratorController: ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager)
        {  
            this.roleManager = roleManager;
        }
    }
}