using ForexAggregator.Api.Database;
using ForexAggregator.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ForexAggregator.Api.Service
{
    public class ForexService : IForexService
    {
        private readonly ForexAggregatorContext _context;
        public ForexService(ForexAggregatorContext context)
        {
            _context = context;
        }
        public ServiceResponse GetProviderByProviderId(long providerId)
        {
            var response = new ServiceResponse();
            var provider = _context.Provider.Include("Location").FirstOrDefault(x => x.ProviderId.Equals(providerId));
            response.Data = provider;
            response.IsSuccessful = true;
            return response;
        }

        public ServiceResponse GetProviderHistory(long providerId, DateTime from, DateTime to, string source, string target)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse GetProviders()
        {
            var response = new ServiceResponse();
            var providers = _context.Provider.Include("Location").ToList();
            response.Data = providers;
            response.IsSuccessful = true;
            return response;
        }

        public ServiceResponse GetRate(string source, string target)
        {
            throw new NotImplementedException();
        }
    }
}
