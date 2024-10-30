using MediatR;
using Thunder.ToDoList.Application.DTOs;

namespace Thunder.ToDoList.Application.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>> { }
