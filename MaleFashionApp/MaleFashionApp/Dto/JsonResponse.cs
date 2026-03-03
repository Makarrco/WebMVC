using MaleFashionApp.Entities;

namespace MaleFashionApp.Dto;

public class JsonResponse
{
    public int Code { get; set; }
    public StatusResponse Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; } = string.Empty;
}