using ForexAggregator.Web.Helper;
using ForexAggregator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ForexAggregator.Web.Controllers
{
    public class AccountController : Controller
    {
        public IConfiguration Configuration { get; }
        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetObjectAsJson("UserName", null);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await HttpClientHelper.PostAsync<ServiceResponse<string>>(Configuration.GetSection("ApiBaseURL").Value + "Account/Login", "", new PostObject() { PostData = model });
            if (result.IsSuccessful)
            {
                HttpContext.Session.SetObjectAsJson("UserName", new UserData() { UserName = model.Email, Token = result.Data.ToString() });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await HttpClientHelper.PostAsync<ServiceResponse<string>>(Configuration.GetSection("ApiBaseURL").Value + "Account/Register", "", new PostObject() { PostData = model });
            if (result.IsSuccessful)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
