using ForexAggregator.Api.Database;
using ForexAggregator.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForexAggregator.Api.Service
{
    public class ForexService : IForexService
    {
        private readonly ForexAggregatorContext _context;
        public ForexService(ForexAggregatorContext context)
        {
            _context = context;
        }
        public Provider GetProviderByProviderId(long providerId)
        {
            var provider = _context.Provider.Include("Location").FirstOrDefault(x => x.ProviderId.Equals(providerId));
            return provider;
        }

        public List<History> GetProviderHistory(long providerId, DateTime from, DateTime to, string source, string target)
        {
            throw new NotImplementedException();
        }

        public List<Provider> GetProviders()
        {
            var providers = _context.Provider.Include("Location").ToList();
            return providers;
        }

        public List<Exchange> GetRate(string source, string target)
        {
            throw new NotImplementedException();
        }
    }
}
