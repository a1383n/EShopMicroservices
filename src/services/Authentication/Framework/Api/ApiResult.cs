using System.Text.Json.Serialization;
using Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Api;

public abstract class ApiResult : IActionResult
{
    public abstract Task ExecuteResultAsync(ActionContext context);
}

public class ApiResult<T> : ApiResult
{
    [JsonPropertyOrder(-2)] 
    public bool IsSuccessful { get; set; }

    [JsonPropertyOrder(-1)] 
    public int StatusCode { get; set; }

    [JsonPropertyOrder(0)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    public ApiResult(bool isSuccessful, int statusCode, T? data)
    {
        IsSuccessful = isSuccessful;
        StatusCode = statusCode;
        Data = data;
    }

    public override Task ExecuteResultAsync(ActionContext context)
    {
        JsonResult jsonResult = new(this)
        {
            StatusCode = StatusCode
        };
        return jsonResult.ExecuteResultAsync(context);
    }

    public static ApiResult<T> Successful(T data, int statusCode = 200)
    {
        return new ApiResult<T>(true, statusCode, data);
    }

    public static ApiResult<Error> Failed(Error error)
    {
        return new ApiResult<Error>(false, error.StatusCode, error);
    }

    public static ApiResult<T> Failed(T error, int statusCode = 400)
    {
        return new ApiResult<T>(false, statusCode, error);
    }

    public static ApiResult<ValidationError> UnprocessableEntity(ValidationError error)
    {
        return new ApiResult<ValidationError>(false, 422, error);
    }
}