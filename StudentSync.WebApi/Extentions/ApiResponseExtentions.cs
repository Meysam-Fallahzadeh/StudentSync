using StudentSync.Application.Model;
using StudentSync.WebApi.Models;

namespace StudentSync.WebApi.Extentions
{
    public static class ApiResponseExtentions
    {
        public static ApiResponse<T> ToApiResponse<T>(this ApplicationServiceResponse<T> applicationService)
        {
            return new ApiResponse<T>()
            {
                Result = applicationService.Result,
                IsSuccess = applicationService.IsSuccess,
                ErrorMessage = applicationService.ErrorMessage,
                ErrorCode = applicationService.ErrorCode
            };
        }
        public static ApiResponse ToApiResponse(this ApplicationServiceResponse applicationService)
        {
            return new ApiResponse()
            {
                IsSuccess = applicationService.IsSuccess,
                ErrorMessage = applicationService.ErrorMessage,
                ErrorCode = applicationService.ErrorCode
            };
        }

    }
}
