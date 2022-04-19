namespace Entities.Concrete
{
    public class ApiLog
    {
        public Guid ApiLogId { get; set; }
        public string UserName { get; set; }
        public int CreatedDate { get; set; }
        public int CreatedTime { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string ServiceName { get; set; }
        public string RouteUrl { get; set; }
        public string Method { get; set; }
        public int StatusCode { get; set; }
        public long Duration { get; set; }
    }
}
