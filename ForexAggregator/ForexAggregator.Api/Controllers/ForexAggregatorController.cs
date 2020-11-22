﻿using ForexAggregator.Api.Models;
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

        [AllowAnonymous]
        [HttpGet]
        public ServiceResponse GetRate(string source, string target)
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
            var response = new ServiceResponse()
            {
                Data = exchanges,
                IsSuccessful = true
            };
            return response;
        }

        [HttpGet]
        public ServiceResponse GetCurrency()
        {
            return _forexService.GetCurrency();
        }
    }
}
