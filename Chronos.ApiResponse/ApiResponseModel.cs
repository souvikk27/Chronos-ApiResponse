namespace Chronos.ApiResponse
{
    public class ApiResponseModel<T>
    {
        public Guid ApiResponseId { get; set; }

        public string? Status { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T Payload { get; set; }

        public ApiResponseModel(ApiResponseStatusEnum status, string message, T payload, string? statusCode = null, Guid? apiResponseId = null)
        {
            ApiResponseId = apiResponseId ?? Guid.NewGuid();
            Status = Enum.GetName(typeof(ApiResponseStatusEnum), status)?.ToLower();
            StatusCode = statusCode != null ? Convert.ToInt32(statusCode) : GetStatusCode(status);
            Message = message;
            Payload = payload;
        }

        private int GetStatusCode(ApiResponseStatusEnum status) => status switch
        {
            ApiResponseStatusEnum.Warning => 429,
            ApiResponseStatusEnum.NotFound => 404,
            ApiResponseStatusEnum.Unauthorized => 401,
            ApiResponseStatusEnum.Forbidden => 403,
            ApiResponseStatusEnum.InternalServerError => 500,
            ApiResponseStatusEnum.Success => 200,
            ApiResponseStatusEnum.Info => 100,
            ApiResponseStatusEnum.Error => 500,
            _ => 0    
        };

    }

    public enum ApiResponseStatusEnum
    {
        NotSet = 0,
        Success,
        Warning,
        Info,
        Error,
        NotFound,
        Unauthorized,
        Forbidden,
        InternalServerError
    }

}
