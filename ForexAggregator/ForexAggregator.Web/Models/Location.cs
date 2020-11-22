namespace ForexAggregator.Web.Models
{
    public class Location
    {
		public long LocationId { get; set; }
		public long ProviderId { get; set; }
		public string CityName { get; set; }
		public string Address { get; set; }
		public long PostCode { get; set; }
	}
}
