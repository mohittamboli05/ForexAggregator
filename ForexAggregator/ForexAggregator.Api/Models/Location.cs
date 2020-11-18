using System.ComponentModel.DataAnnotations.Schema;

namespace ForexAggregator.Api.Models
{
    public class Location
	{
		public long LocationId { get; set; }
		[ForeignKey("Provider")]
		public long ProviderId { get; set; }
		public string CityName { get; set; }
		public string Address { get; set; }
		public long PostCode { get; set; }
		//public virtual Provider Provider { get; set; }
	}
}
