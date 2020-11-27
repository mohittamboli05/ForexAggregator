using ForexAggregator.Api.Models;
using System;

namespace ForexAggregator.Api.Service
{
    public interface IForexService
    {
        ServiceResponse GetProviders();
        ServiceResponse GetProviderByProviderId(long providerId);
        ServiceResponse GetProviderHistory(long providerId, DateTime from, DateTime to, string source, string target);
        ServiceResponse GetExchangeRate(string source, string target);
        ServiceResponse GetExchangeRateByProviderId(string source, string target, long providerId);
        ServiceResponse GetCurrency();
    }
}
