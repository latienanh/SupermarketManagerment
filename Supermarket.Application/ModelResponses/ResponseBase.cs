using System.Net;

namespace Supermarket.Application.ModelResponses;

public class ResponseBase
{
    public string Type { get; set; } 
    public string Title { get; set; } 
    public HttpStatusCode Status { get; set; } 
    public string? Message { get; set; }
    public Dictionary<string, string[]> Errors { get; init; } = new();

    public string TraceId { get; init; } = string.Empty;
}