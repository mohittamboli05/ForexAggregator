namespace ForexAggregator.Web.Models
{
    public class PostObject
    {
        public object PostData { get; set; }
    }

    public class Response
    {
        public bool IsSuccessful { get; set; }
        public object Data { get; set; }
    }
}
