using System.Net;

namespace Thunder.ToDoList.Domain.Exceptions;

public sealed class BadRequestException : HttpException
{
    public BadRequestException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}