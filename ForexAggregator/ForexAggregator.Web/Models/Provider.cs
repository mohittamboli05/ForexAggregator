namespace ForexAggregator.Web.Models
{
    public class Provider
    {
        public long ProviderId { get; set; }
        public string ProviderName { get; set; }
        public virtual Location Location { get; set; }
        public virtual History History { get; set; }
        public virtual Exchange Exchange { get; set; }
    }
}
