using Microsoft.AspNetCore.Mvc;

namespace Chronos.ApiResponse
{
    public static class ApiResponseExtension
    {
        private const string GenericSuccessMessage = "The operation completed succesfully.";
        private const string GenericWarningMessage = "The operation completed with warnings.";
        private const string GenericErrorMessage = "The operation completed with errors.";
        private const string GenericNotFoundMessage = "The requested resource was not found.";
        private const string GenericUnauthorizedMessage = "Unauthorized access.";
        private const string GenericForbiddenMessage = "Access to the resource is forbidden.";
        private const string GenericInternalServerErrorMessage = "An internal server error occurred.";

        public static ObjectResult ToSuccessApiResult(object payload, string message = null!, string statusCode = null!) =>
        new OkObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.Success,
                    message ?? GenericSuccessMessage,
                    payload,
                    statusCode));

        public static ObjectResult ToWarningApiResult(object payload, string message = null!, string statusCode = null!) =>
        new ObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.Warning,
                    message ?? GenericWarningMessage,
                    payload,
                    statusCode));

        public static ObjectResult ToInfoApiResult(object payload, string message = null!, string statusCode = null!) =>
            new OkObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.Info,
                    message,
                    payload,
                    statusCode));

        public static ObjectResult ToErrorApiResult(object payload, string message = null!, string statusCode = null!) =>
            new OkObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.Error,
                    message ?? GenericErrorMessage,
                    payload,
                    statusCode));

        public static ObjectResult ToNotFoundApiResult(object payload, string message = null!, string statusCode = null!) =>
            new NotFoundObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.NotFound,
                    message ?? GenericNotFoundMessage,
                    payload,
                    statusCode));

        public static ObjectResult ToUnauthorizedApiResult(object payload, string message = null!, string statusCode = null!) =>
            new UnauthorizedObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.Unauthorized,
                    message ?? GenericUnauthorizedMessage,
                    payload,
                    statusCode));

        public static ObjectResult ToForbiddenApiResult(object payload, string message = null!, string statusCode = null!) =>
            new ObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.Forbidden,
                    message ?? GenericForbiddenMessage,
                    payload,
                    statusCode))
            {
                StatusCode = 403
            };

        public static ObjectResult ToInternalServerErrorApiResult(object payload, string message = null!, string statusCode = null!) =>
            new ObjectResult(
                new ApiResponseModel<object>(
                    ApiResponseStatusEnum.InternalServerError,
                    message ?? GenericInternalServerErrorMessage,
                    payload,
                    statusCode))
            {
                StatusCode = 500
            };

        public static ObjectResult ToPaginatedApiResult(object payload,
            string message = null!,
            string statusCode = null!,
            int currentPage = 0,
            int totalPages = 0) =>
            new ObjectResult(
                new PaginatedResponseModel<object>(
                    ApiResponseStatusEnum.Success,
                    message ?? GenericSuccessMessage,
                    payload,
                    statusCode,
                    Guid.NewGuid(),
                    currentPage,
                    totalPages));
    }
}