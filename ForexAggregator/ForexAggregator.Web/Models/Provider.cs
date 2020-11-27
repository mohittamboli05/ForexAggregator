using System.Collections.Generic;

namespace ForexAggregator.Web.Models
{
    public class Provider
    {
        public long ProviderId { get; set; }
        public string ProviderName { get; set; }
        public virtual Location Location { get; set; }
        public virtual History History { get; set; }
        public virtual IEnumerable<Exchange> Exchange { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
