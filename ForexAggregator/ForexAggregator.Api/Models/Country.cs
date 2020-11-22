using System.ComponentModel.DataAnnotations;

namespace ForexAggregator.Api.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
    }
}
