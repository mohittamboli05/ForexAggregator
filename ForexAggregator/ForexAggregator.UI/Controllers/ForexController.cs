using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForexAggregator.UI.Helper;
using ForexAggregator.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ForexAggregator.UI.Controllers
{
    public class ForexController : Controller
    {
        public IConfiguration Configuration { get; }
        public ForexController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var result = await HttpClientHelper.GetAsync<ServiceResponse>(Configuration.GetSection("ApiBaseURL").Value + "/api/ForexAggregator/GetProviders", "");
            return View();
        }
    }
}
