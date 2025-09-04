using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace TaskManagement1.Controllers
{
    public class ManageRoleController : Controller
    {

        private RoleManager<IdentityRole> _roleManager;

        public ManageRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.OrderBy(r => r.Name).ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            var result=await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string msg = "";
                foreach(var error in result.Errors)
                {
                    //msg += error.Code + error.Description + "\n";
                    msg += $"{error.Code} - {error.Description}\n";
                }
                ViewBag.Msg = msg;  
            }
            return View();
        }
    }
}
