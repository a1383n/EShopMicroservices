using System.Text.Json.Serialization;

namespace Common.Model;

public abstract class Error
{
    public string Title { get; set; }
    
    [JsonIgnore]
    public int StatusCode { get; set; }
    //TODO: It's good idea to change http status code with internal error code system
}