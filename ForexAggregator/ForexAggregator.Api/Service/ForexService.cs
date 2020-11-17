using ForexAggregator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForexAggregator.Api.Service
{
    public class ForexService : IForexService
    {

        public Provider GetProviderByProviderId(long providerId)
        {
            throw new NotImplementedException();
        }

        public List<History> GetProviderHistory(long providerId, DateTime from, DateTime to, string source, string target)
        {
            throw new NotImplementedException();
        }

        public List<Provider> GetProviders()
        {
            throw new NotImplementedException();
        }

        public List<Exchange> GetRate(string source, string target)
        {
            throw new NotImplementedException();
        }
    }
}
