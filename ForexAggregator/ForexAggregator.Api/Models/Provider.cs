using System.ComponentModel.DataAnnotations;

namespace ForexAggregator.Api.Models
{
    public class Provider
	{
		[Key]
		public long ProviderId { get; set; }
		public string ProviderName { get; set; }
		public virtual Location Location { get; set; }
		public virtual History History { get; set; }
		public virtual Exchange Exchange { get; set; }
	}
}
