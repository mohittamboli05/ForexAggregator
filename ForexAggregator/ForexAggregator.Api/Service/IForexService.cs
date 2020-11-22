using ForexAggregator.Api.Models;
using System;

namespace ForexAggregator.Api.Service
{
    public interface IForexService
    {
        ServiceResponse GetProviders();
        ServiceResponse GetProviderByProviderId(long providerId);
        ServiceResponse GetProviderHistory(long providerId, DateTime from, DateTime to, string source, string target);
        ServiceResponse GetRate(string source, string target);
        ServiceResponse GetCurrency();
    }
}
