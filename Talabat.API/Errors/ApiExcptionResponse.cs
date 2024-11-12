namespace Talabat.API.Errors
{
    public class ApiExcptionResponse:ApiResponse
    {
        public string? Details { get; set; }
        public ApiExcptionResponse(int StatusCode ,string? details, string? Message = null) :base(StatusCode, Message)
        {
            Details = details;
        }
    }
}
