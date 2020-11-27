using System;

namespace ForexAggregator.Web.Models
{
    public class ExchangeRateHistory
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public Result[] response { get; set; }
        public Info info { get; set; }
        public Provider Provider { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }

    public class Info
    {
        public string id { get; set; }
        public string _decimal { get; set; }
        public string symbol { get; set; }
        public string period { get; set; }
        public string server_time { get; set; }
        public int credit_count { get; set; }
    }

    public class Result
    {
        public string o { get; set; }
        public string h { get; set; }
        public string l { get; set; }
        public string c { get; set; }
        public string v { get; set; }
        public int t { get; set; }
        public DateTime tm { get; set; }
    }
}
