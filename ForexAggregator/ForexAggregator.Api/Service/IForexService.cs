using ForexAggregator.Api.Models;
using System;
using System.Collections.Generic;

namespace ForexAggregator.Api.Service
{
    public interface IForexService
    {
        List<Provider> GetProviders();
        Provider GetProviderByProviderId(long providerId);
        List<History> GetProviderHistory(long providerId, DateTime from, DateTime to, string source, string target);
        List<Exchange> GetRate(string source, string target);
    }
}
