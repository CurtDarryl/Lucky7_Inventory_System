using System.Net;

namespace Lucky7_Inventory_System_Application.Responses;

public class ServiceResponses
{
    public record class GetResponse(bool IsSuccess, object? data, string Message, HttpStatusCode Status);
}
