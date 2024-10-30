using FluentValidation;
using Thunder.ToDoList.Application.Commands;

namespace Thunder.ToDoList.Application.Validations;

public class UpdateTaskItemCommandValidator : AbstractValidator<UpdateTaskItemCommand>
{
    public UpdateTaskItemCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();
    }
}