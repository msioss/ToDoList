using FluentValidation;
using ToDoList.ViewModels;

namespace ToDoList.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskViewModel>
    {
        public CreateTaskValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithName("Name").WithMessage("Name is necessary")
                .MinimumLength(1).WithName("Name").WithMessage("Name must be bigger than 1 symb");
        }
    }
}
