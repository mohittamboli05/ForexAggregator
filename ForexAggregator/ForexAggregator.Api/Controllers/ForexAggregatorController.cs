using ForexAggregator.Api.Models;
using ForexAggregator.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ForexAggregator.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ForexAggregatorController : ControllerBase
    {
        private readonly IForexService _forexService;
        public ForexAggregatorController(IForexService forexService)
        {
            _forexService = forexService;
        }

        [HttpGet]
        public List<Provider> GetProviders()
        {
            return _forexService.GetProviders();
        }

        [HttpGet]
        public Provider GetProviderByProviderId(long providerId)
        {
            return new Provider()
            {
                ProviderId = 1,
                ProviderName = "Provider 1",
                ProviderLocation = new Location()
                {
                    ProviderId = 1,
                    Address = "Mumbai",
                    CityName = "Mumbai",
                    LocationId = 1,
                    PostCode = 12345
                }
            };
        }

        [AllowAnonymous]
        [HttpGet]
        public List<Exchange> GetRate(string source, string target)
        {
            var exchanges = new List<Exchange>()
            {
                new Exchange()
                {
                     Date=DateTime.Now,
                     ExchangeId=1,
                     ProviderId=1,
                     SourceCurrency="GBP",
                     TargetCurrency="INR"
                },
                new Exchange()
                {
                     Date=DateTime.Now,
                     ExchangeId=2,
                     ProviderId=2,
                     SourceCurrency="GBP",
                     TargetCurrency="INR"
                },
                new Exchange()
                {
                     Date=DateTime.Now,
                     ExchangeId=3,
                     ProviderId=3,
                     SourceCurrency="GBP",
                     TargetCurrency="INR"
                }
            };
            return exchanges;
        }
    }
}
