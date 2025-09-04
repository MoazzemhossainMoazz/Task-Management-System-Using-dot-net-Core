using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement1.Data;

namespace TaskManagement1.Controllers
{
    public class AuthenticUserController : Controller
    {
        private readonly TaskContextData _dbContext;

        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticUserController(TaskContextData dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> LogOut(string returnUrl)
        {

            await _signInManager.SignOutAsync();
           // _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToAction();
            }
        }
    }
}
