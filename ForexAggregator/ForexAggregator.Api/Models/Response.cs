namespace ForexAggregator.Api.Models
{
    public class ServiceResponse
    {
        public bool IsSuccessful { get; set; }
        public object Data { get; set; }
    }

    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
