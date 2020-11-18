using ForexAggregator.Api.Models;
using Microsoft.AspNetCore.Identity;
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
            if (!_forexAggregatorContext.ApplicationRole.Any())
            {
                var roles = new List<ApplicationRole>()
                {
                    new ApplicationRole()
                    {
                         Name="Customer",
                         NormalizedName="Customer"
                    }
                };
                await _forexAggregatorContext.ApplicationRole.AddRangeAsync(roles);
                await _forexAggregatorContext.SaveChangesAsync();
            }

            if (!_forexAggregatorContext.ApplicationUser.Any())
            {
                var hasher = new PasswordHasher<IdentityUser>();
                var hashed = hasher.HashPassword(null, "Secure*12");
                var users = new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                        FirstName = "Mohit",
                        LastName = "Tamboli",
                        Email = "mohit.tamboli@gmail.com",
                        NormalizedEmail = "mohit.tamboli@gmail.com".ToUpper(),
                        UserName = "mohit.tamboli@gmail.com",
                        NormalizedUserName = "mohit.tamboli@gmail.com".ToUpper(),
                        PhoneNumber = "+919876543210",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PasswordHash= hashed
                    }
                };

                await _forexAggregatorContext.ApplicationUser.AddRangeAsync(users);
                await _forexAggregatorContext.SaveChangesAsync();
            }

            if (!_forexAggregatorContext.ApplicationUserRole.Any())
            {
                var userRoles = new List<ApplicationUserRole>();
                var roleId = _forexAggregatorContext.ApplicationRole.FirstOrDefault().Id;
                var users = _forexAggregatorContext.ApplicationUser.ToList();
                foreach (var user in users)
                {
                    userRoles.Add(new ApplicationUserRole()
                    {
                        UserId = user.Id,
                        RoleId = roleId
                    });
                }
                await _forexAggregatorContext.ApplicationUserRole.AddRangeAsync(userRoles);
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
