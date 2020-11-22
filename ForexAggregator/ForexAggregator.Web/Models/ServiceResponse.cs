namespace ForexAggregator.Web.Models
{
    public class ServiceResponse<T> : BaseServiceResponse
    {
        public T Data { get; set; }
    }
    public class BaseServiceResponse
    {
        public bool IsSuccessful { get; set; }
    }
}
