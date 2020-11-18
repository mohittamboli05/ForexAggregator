using ForexAggregator.Api.Models;
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
        [HttpGet]
        public List<Provider> GetProviders()
        {
            var providers = new List<Provider>() {
                new Provider()
                {
                    ProviderId=1,
                    ProviderName="Provider 1",
                    ProviderLocation=new Location()
                    {
                        ProviderId=1,
                        Address="Mumbai",
                        CityName="Mumbai",
                        LocationId=1,
                        PostCode=12345
                    }
                },
                new Provider()
                {
                    ProviderId=2,
                    ProviderName="Provider 2",
                    ProviderLocation=new Location()
                    {
                        ProviderId=2,
                        Address="Delhi",
                        CityName="Delhi",
                        LocationId=2,
                        PostCode=234543
                    }
                },
                new Provider()
                {
                    ProviderId=3,
                    ProviderName="Provider 3",
                    ProviderLocation=new Location()
                    {
                        ProviderId=3,
                        Address="Pune",
                        CityName="Pune",
                        LocationId=3,
                        PostCode=85749
                    }
                }
           };
            return providers;
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
