using ForexAggregator.Api.Models;
using ForexAggregator.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ForexAggregator.Api.Controllers
{
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
        public ServiceResponse GetProviders()
        {
            return _forexService.GetProviders();
        }

        [HttpGet]
        public ServiceResponse GetProviderByProviderId(long providerId)
        {
            return _forexService.GetProviderByProviderId(providerId);
        }

        [HttpGet]
        public ServiceResponse GetExchangeRate(string sourceCurrency, string targetCurrency)
        {
            return _forexService.GetExchangeRate(sourceCurrency, targetCurrency);
        }

        [HttpGet]
        public ServiceResponse GetCurrency()
        {
            return _forexService.GetCurrency();
        }
    }
}
