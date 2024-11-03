namespace StudentSync.WebApi.Models
{
    public class ApiResponse<T> : ApiResponse
    {
        public T Result { get; set; }

    }
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }

    }
}
