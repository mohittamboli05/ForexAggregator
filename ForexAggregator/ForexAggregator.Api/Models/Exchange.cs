﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexAggregator.Api.Models
{
    public class Exchange
	{
		[Key]
		public long ExchangeId { get; set; }
		[ForeignKey("Provider")]
		public long ProviderId { get; set; }
		public string SourceCurrency { get; set; }
		public string TargetCurrency { get; set; }
		public decimal ExchangeRate { get; set; }
		public DateTime Date { get; set; }
	}
}
