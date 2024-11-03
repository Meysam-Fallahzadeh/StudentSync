namespace StudentSync.Application.Model
{
    public class ApplicationServiceResponse<T> : ApplicationServiceResponse
    {
        public T Result { get; set; }


    }
    public class ApplicationServiceResponse
    {
        public bool IsSuccess {  get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode {  get; set; }


        public static ApplicationServiceResponse<T> CreateSuccessResponse<T>(T resutl)
        {
            return new ApplicationServiceResponse<T>()
            {
                Result = resutl,
                IsSuccess = true,
            };
        }

        public static ApplicationServiceResponse<T> CreateFaileResponse<T>(int errorCode = 0, string errorMessage = "خطای غیر منتظره رخداده است.")
        {
            return new ApplicationServiceResponse<T>
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
        public static ApplicationServiceResponse CreateSuccessResponse()
        {
            return new ApplicationServiceResponse()
            {
                IsSuccess = true,
            };
        }

        public static ApplicationServiceResponse CreateFaileResponse(int errorCode = 0, string errorMessage = "خطای غیر منتظره رخداده است.")
        {
            return new ApplicationServiceResponse
            {
                IsSuccess = false,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }

    }
}
