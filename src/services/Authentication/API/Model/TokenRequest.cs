using System.Text.Json.Serialization;

namespace API.Model;

public class TokenRequest
{
    public Credential Credential { get; set; }
    
    [JsonPropertyName("device")]
    public DeviceDto DeviceDto { get; set; }
}