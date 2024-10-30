using MediatR;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Application.Queries;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.Application.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var userDtos = users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        });

        return userDtos;
    }
}
