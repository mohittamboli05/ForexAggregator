using ForexAggregator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForexAggregator.Api.Service
{
    public class ForexService : IForexService
    {
        private readonly Database.Dapper appContext;
        public ForexService(Database.Dapper dapper)
        {
            appContext = dapper;
        }
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

        public List<Exchange> GetRate(string source, string target)
        {
            throw new NotImplementedException();
        }
    }
}
