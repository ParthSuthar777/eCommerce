using System.Net;

namespace Common.Helper
{
    public class BaseResponseModel<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public int ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}
