using System;

namespace ForexAggregator.Web.Models
{
    public class Exchange
    {
		public long ExchangeId { get; set; }
		public long ProviderId { get; set; }
		public string SourceCurrency { get; set; }
		public string TargetCurrency { get; set; }
		public DateTime Date { get; set; }
	}
}
