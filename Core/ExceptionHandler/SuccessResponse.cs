using Newtonsoft.Json;

namespace Core.ExceptionHandler
{
    public class SuccessResponse
    {
        public bool IsSuccessful { get; set; } = true;
        public int StatusCode { get; set; }
        public string CorrelationId { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
