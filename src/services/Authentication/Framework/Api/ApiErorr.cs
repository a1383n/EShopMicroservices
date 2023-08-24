using System.Text.Json.Serialization;

namespace Framework.Api;

public class ApiError
{
    [JsonPropertyOrder(1)]
    public string Error { get; }

    [JsonPropertyOrder(0)]
    public int StatusCode { get; }

    [JsonPropertyOrder(2)]
    public string? Message { get; }

    public ApiError(string error, int statusCode = 400, string? message = null)
    {
        StatusCode = statusCode;
        Error = error;
        Message = message;
    }
}