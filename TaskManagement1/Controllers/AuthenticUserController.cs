using Microsoft.AspNetCore.Mvc;

namespace TaskManagement1.Controllers
{
    public class AuthenticUserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
