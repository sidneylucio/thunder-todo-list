using MediatR;
using Thunder.ToDoList.Application.Commands;
using Thunder.ToDoList.Application.DTOs;
using Thunder.ToDoList.Domain.Interfaces;
using Entities = Thunder.ToDoList.Domain.Entities;

namespace Thunder.ToDoList.Application.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new Entities.User(request.Name, request.Email);

        await _userRepository.AddAsync(user, cancellationToken);

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}
