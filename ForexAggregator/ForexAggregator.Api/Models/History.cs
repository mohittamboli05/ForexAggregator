using System;

namespace ForexAggregator.Api.Models
{
    public class History
	{
		public long HistoryId { get; set; }
		public DateTime Date { get; set; }
		public decimal Rate { get; set; }
		public string SourceCurrency { get; set; }
		public string TargetCurrency { get; set; }
		public long ProviderId { get; set; }
	}
}
