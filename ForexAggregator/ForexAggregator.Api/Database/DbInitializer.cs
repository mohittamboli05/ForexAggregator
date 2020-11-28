using ForexAggregator.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            if (!_forexAggregatorContext.Country.Any())
            {
                var country = new List<Country>()
                {
                    new Country(){ CountryName="United States", CurrencyCode="USD", CurrencyName="United States dollar", CurrencySymbol="$" },
                    new Country(){ CountryName="United KIngdom", CurrencyCode="GBP", CurrencyName="British pound", CurrencySymbol="£" },
                    new Country(){ CountryName="Japan", CurrencyCode="JPY", CurrencyName="Japanese yen", CurrencySymbol="¥" },
                    new Country(){ CountryName="Jordan", CurrencyCode="JOD", CurrencyName="Jordanian dinar", CurrencySymbol="§" },
                    new Country(){ CountryName="India", CurrencyCode="INR", CurrencyName="Indian rupee", CurrencySymbol="₹" }
                };
                await _forexAggregatorContext.Country.AddRangeAsync(country);
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
                             CityName="Pune",
                             Address="Yerwada",
                             PostCode=411006
                        },
                        Exchange=new List<Exchange>()
                        {
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=72.06M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=98.64M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.71M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=104.44M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0072M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.06M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.010M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=103.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=138.20M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=146.32M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.40M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.71M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.94M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0068M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0096M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.33M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0096M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.41M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.014M }
                        }
                    },
                    new Provider()
                    {
                        ProviderName="eToro",
                        Location=new Location()
                        {
                             CityName="Pune",
                             Address="Kothrud",
                             PostCode=423564
                        },
                        Exchange=new List<Exchange>()
                        {
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=71.01M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=99.64M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.75M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=105.44M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.78M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0079M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.16M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.020M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=104.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=139.20M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=147.32M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.45M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.99M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0078M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.43M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.61M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.034M }
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
                        },
                        Exchange=new List<Exchange>()
                        {
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=70.66M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=97.64M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.75M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=103.44M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.79M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0082M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.08M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.030M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=104.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=135.20M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=149.32M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.50M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.41M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.84M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0078M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.93M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.51M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.034M }
                        }
                    },
                    new Provider()
                    {
                        ProviderName="Libertex",
                        Location=new Location()
                        {
                             CityName="Pune",
                             Address="Viman Nagar",
                             PostCode=865467
                        },
                        Exchange=new List<Exchange>()
                        {
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=68.35M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=97.64M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.61M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=105.44M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.95M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0082M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.09M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.040M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=105.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=136.20M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=144.32M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.90M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.31M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.84M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0078M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.43M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.61M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.034M }
                        }
                    },
                    new Provider()
                    {
                        ProviderName="ICICI",
                        Location=new Location()
                        {
                             CityName="Pune",
                             Address="Baner",
                             PostCode=38001

                        },
                        Exchange=new List<Exchange>()
                        {
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=69.60M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=99.64M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.81M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=105.44M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.65M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0062M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.07M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.020M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=102.75M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=139.20M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=145.32M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.50M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.81M },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.84M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0078M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0096M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.43M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0086M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.51M},
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.024M }
                        }
                    }
                };
                await _forexAggregatorContext.Provider.AddRangeAsync(providers);
                await _forexAggregatorContext.SaveChangesAsync();
            }
        }
    }
}
