using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexAggregator.Api.Models
{
    public class History
	{
		public long HistoryId { get; set; }
		public DateTime Date { get; set; }
		public decimal Rate { get; set; }
		public string SourceCurrency { get; set; }
		public string TargetCurrency { get; set; }
		[ForeignKey("Provider")]
		public long ProviderId { get; set; }
	}
}
