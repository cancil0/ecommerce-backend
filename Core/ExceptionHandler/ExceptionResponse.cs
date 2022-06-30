﻿using Newtonsoft.Json;

namespace Core.ExceptionHandler
{
    public class ExceptionResponse
    {
        public bool IsSuccessful { get; set; } = false;
        public int StatusCode { get; set; }
        public string CorrelationId { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
