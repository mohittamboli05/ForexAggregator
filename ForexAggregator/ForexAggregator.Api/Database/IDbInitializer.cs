using System.Threading.Tasks;

namespace ForexAggregator.Api.Database
{
    public interface IDbInitializer
    {
        void Initialize();
        Task Seed();
    }
}
