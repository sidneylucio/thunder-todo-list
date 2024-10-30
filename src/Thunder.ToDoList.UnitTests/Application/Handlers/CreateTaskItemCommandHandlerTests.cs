using Moq;
using Thunder.ToDoList.Application.Commands;
using Thunder.ToDoList.Application.Handlers;
using Thunder.ToDoList.Domain.Entities;
using Thunder.ToDoList.Domain.Interfaces;

namespace Thunder.ToDoList.UnitTests.Application.Handlers;

public class CreateTaskItemCommandHandlerTests
{
    private readonly Mock<ITaskItemRepository> _taskItemRepositoryMock;
    private readonly CreateTaskItemCommandHandler _handler;

    public CreateTaskItemCommandHandlerTests()
    {
        // Inicializa o mock do repositório
        _taskItemRepositoryMock = new Mock<ITaskItemRepository>();
        _handler = new CreateTaskItemCommandHandler(_taskItemRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateTaskItemAndReturnTaskItemDto()
    {
        // Arrange
        var command = new CreateTaskItemCommand("Test Task", "Test Description", Guid.NewGuid(), DateTime.UtcNow.AddDays(5));

        var taskItem = new TaskItem(command.Title, command.Description, command.UserId, command.DueDate);

        _taskItemRepositoryMock
            .Setup(repo => repo.AddAsync(It.IsAny<TaskItem>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(taskItem);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(taskItem.Id, result.Id);
        Assert.Equal(command.Title, result.Title);
        Assert.Equal(command.Description, result.Description);
        Assert.Equal(command.UserId, result.UserId);
        Assert.Equal(command.DueDate, result.DueDate);

        _taskItemRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<TaskItem>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
