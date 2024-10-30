using System.Net;

namespace Thunder.ToDoList.Domain.Exceptions;

public sealed class NotFoundException : HttpException
{
    public NotFoundException(string message) : base(message)
    {
        base.StatusCode = HttpStatusCode.NotFound;
    }
}