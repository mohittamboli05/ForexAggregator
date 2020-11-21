using ForexAggregator.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForexAggregator.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl)
        {
            return View();
        }
    }
}
