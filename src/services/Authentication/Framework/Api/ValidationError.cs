using System.Text.Json.Serialization;
using Common.Model;
using FluentValidation.Results;

namespace Framework.Api;

public class ValidationError: Error
{
    [JsonPropertyOrder(0)]
    public Dictionary<string, string> Errors { get; } = new();

    public ValidationError(List<ValidationFailure> errors)
    {
        Title = "validation_error";
        StatusCode = 422;
        
        foreach (var validationFailure in errors)
        {
            Errors.Add(validationFailure.PropertyName.ToLower(),validationFailure.ErrorMessage);
        }
    }
}