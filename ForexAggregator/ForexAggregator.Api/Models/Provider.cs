namespace ForexAggregator.Api.Models
{
    public class Provider
	{
		public long ProviderId { get; set; }
		public string ProviderName { get; set; }
		public virtual Location Location { get; set; }
	}
}
