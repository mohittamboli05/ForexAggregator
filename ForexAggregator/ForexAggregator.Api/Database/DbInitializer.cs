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
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=72.06M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=97.97M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.61M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=103.33M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.65M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0062M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.01M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.0010M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=102.75M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=137.20M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=145.32M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.30M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.61M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.84M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0058M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0086M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.43M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0086M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.31M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.012M     }
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
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=71.06M   },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=96.97M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.51M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=102.33M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.55M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0052M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=1.00M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.0008M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=102.65M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=137.10M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=145.12M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.20M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.51M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.74M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0048M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0076M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.33M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0076M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.21M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.003M     }
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
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=71.01M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=95.97M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.41M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=102.23M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.45M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0042M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=0.99M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.0007M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=102.55M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=137.00M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=145.10M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.10M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.41M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.64M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0038M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0066M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.23M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0066M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.11M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.002M     }
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
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=70.50M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=95.87M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.31M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=102.20M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.40M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0040M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=0.90M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.0005M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=102.50M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=136.50M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=145.00M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=1.00M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.31M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.54M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0028M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0056M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.13M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0056M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.01M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.001M     }
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
                           new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="INR", ExchangeRate=70.00M  },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="INR", ExchangeRate=95.77M     },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="INR", ExchangeRate=0.21M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="INR", ExchangeRate=102.10M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="GBP", ExchangeRate=0.30M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="GBP", ExchangeRate=0.0030M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="GBP", ExchangeRate=0.80M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="GBP", ExchangeRate=0.0003M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JPY", ExchangeRate=102.00M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JPY", ExchangeRate=136.00M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="JPY", ExchangeRate=144.50M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JPY", ExchangeRate=0.90M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="USD", TargetCurrency="JOD", ExchangeRate=0.21M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="JOD", ExchangeRate=0.44M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="JOD", ExchangeRate=0.0018M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="JOD", ExchangeRate=0.0036M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="GBP", TargetCurrency="USD", ExchangeRate=1.03M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JPY", TargetCurrency="USD", ExchangeRate=0.0046M    },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="JOD", TargetCurrency="USD", ExchangeRate=1.00M      },
                            new Exchange(){ Date= DateTime.Now, SourceCurrency="INR", TargetCurrency="USD", ExchangeRate=0.0009M    }
                        }
                    }
                };
                await _forexAggregatorContext.Provider.AddRangeAsync(providers);
                await _forexAggregatorContext.SaveChangesAsync();
            }
        }
    }
}
