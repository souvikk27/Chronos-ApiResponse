namespace Chronos.ApiResponse
{
    public class PaginatedResponseModel<T>
    {
        public Guid ApiResponseId { get; set; }

        public string? Status { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public T Payload { get; set; }

        public PaginatedResponseModel(ApiResponseStatusEnum status, string message, T payload,
            string? statusCode = null, Guid? apiResponseId = null,
            int currentPage = 0, int totalPages = 0)
        {
            ApiResponseId = apiResponseId ?? Guid.NewGuid();
            Status = Enum.GetName(typeof(ApiResponseStatusEnum), status)?.ToLower();
            StatusCode = statusCode != null ? Convert.ToInt32(statusCode) : GetStatusCode(status);
            Message = message;
            CurrentPage = currentPage;
            TotalPages = totalPages;
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
}