using ForexAggregator.Web.Helper;
using ForexAggregator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ForexAggregator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCurrency()
        {
            var result = await HttpClientHelper.GetAsync<ServiceResponse<List<Currency>>>(Configuration.GetSection("ApiBaseURL").Value + "ForexAggregator/GetCurrency", "");
            if (result.IsSuccessful)
            {
                if (Request.IsAjaxRequest())
                    return Json(result.Data);
            }
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> GetProviders(string sourceCurrency, string targetCurrency)
        {
            var result = await HttpClientHelper.GetAsync<ServiceResponse<List<Provider>>>(Configuration.GetSection("ApiBaseURL").Value +
                "ForexAggregator/GetExchangeRate?sourceCurrency=" + sourceCurrency + "&targetCurrency=" + targetCurrency, "");
            if (result.IsSuccessful)
            {
                foreach (var item in result.Data)
                    item.Rate = item.Exchange.FirstOrDefault().ExchangeRate;
                return PartialView(result.Data);
            }
            return PartialView(new List<Provider>());
        }

        public async Task<IActionResult> ProviderHistory(int providerId, string sourceCurrency, string targetCurrency)
        {
            ViewBag.ProviderId = providerId;
            var provider = await HttpClientHelper.GetAsync<ServiceResponse<Provider>>(Configuration.GetSection("ApiBaseURL").Value + "ForexAggregator/GetProviderByProviderId?providerId=" + providerId, "");
            provider.Data.SourceCurrency = sourceCurrency;
            provider.Data.TargetCurrency = targetCurrency;
            return View(provider.Data);
        }

        public async Task<IActionResult> GetHistory(string sourceCurrency, string targetCurrency)
        {
            string request = string.Format("https://fcsapi.com/api-v3/forex/history?symbol={0}/{1}&period={2}&access_key=gpgjcVKG15ckcgn09QFtBCuOh", sourceCurrency, targetCurrency, "1d");
            var result = await HttpClientHelper.GetAsync<ExchangeRateHistory>(request, "");
            var processedResult = result.response.Where(x => x.tm.Year == DateTime.Now.Year).ToList();
            if (Request.IsAjaxRequest())
                return Json(processedResult);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProviderDetails(Provider model)
        {
            var provider = await HttpClientHelper.GetAsync<ServiceResponse<Provider>>(Configuration.GetSection("ApiBaseURL").Value + "ForexAggregator/GetExchangeRateByProviderId?providerId=" + model.ProviderId+"&sourceCurrency= " + model.SourceCurrency + "&targetCurrency=" + model.TargetCurrency, "");
            return View(provider.Data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
