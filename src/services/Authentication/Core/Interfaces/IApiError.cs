using System.Text.Json.Serialization;

namespace Core.Interfaces;

public abstract class IApiError
{
    [JsonPropertyOrder(-2)]
    public string Error { get; set; }
    
    [JsonIgnore]
    public int StatusCode { get; set; }
}