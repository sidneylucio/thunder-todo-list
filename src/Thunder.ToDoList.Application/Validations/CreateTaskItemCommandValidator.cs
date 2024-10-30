using FluentValidation;
using Thunder.ToDoList.Application.Commands;

namespace Thunder.ToDoList.Application.Validations;

public class CreateTaskItemCommandValidator : AbstractValidator<CreateTaskItemCommand>
{
    public CreateTaskItemCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();
    }
}