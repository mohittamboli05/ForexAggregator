using ForexAggregator.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForexAggregator.Api.Database
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ForexAggregatorContext _forexAggregatorContext;
        public DbInitializer(ForexAggregatorContext forexAggregatorContext)
        {
            _forexAggregatorContext = forexAggregatorContext;
        }

        public void Initialize()
        {
            _forexAggregatorContext.Database.Migrate();
        }

        public async Task Seed()
        {
            if(!_forexAggregatorContext.ApplicationRole.Any())
            {
                var roles = new List<ApplicationRole>() 
                { 
                    new ApplicationRole()
                    {
                         Name="Customer",
                         NormalizedName="Customer"
                    },
                    new ApplicationRole()
                    {
                         Name="Admin",
                         NormalizedName="Admin"
                    }
                };
                await _forexAggregatorContext.ApplicationRole.AddRangeAsync(roles);
                await _forexAggregatorContext.SaveChangesAsync();
            }

            if (!_forexAggregatorContext.Provider.Any())
            {
                var providers = new List<Provider>()
                {
                    new Provider()
                    {
                        ProviderName="Western Union",
                        Location=new Location()
                        {
                             CityName="Indore",
                             Address="Vijay Nagar",
                             PostCode=452001
                        }
                    },
                    new Provider()
                    {
                        ProviderName="eToro",
                        Location=new Location()
                        {
                             CityName="Mumbai",
                             Address="Navi Mumbai",
                             PostCode=423564
                        }
                    },
                    new Provider()
                    {
                        ProviderName="OctaFX",
                        Location=new Location()
                        {
                             CityName="Pune",
                             Address="Hinjewadi",
                             PostCode=643241
                        }
                    },
                    new Provider()
                    {
                        ProviderName="Libertex",
                        Location=new Location()
                        {
                             CityName="Chennai",
                             Address="Anna Nagar",
                             PostCode=865467
                        }
                    },
                    new Provider()
                    {
                        ProviderName="ICICI",
                        Location=new Location()
                        {
                             CityName="Ahmedabad",
                             Address="Satelite",
                             PostCode=38001
                        }
                    }
                };
                await _forexAggregatorContext.Provider.AddRangeAsync(providers);
                await _forexAggregatorContext.SaveChangesAsync();
            }
        }
    }
}
