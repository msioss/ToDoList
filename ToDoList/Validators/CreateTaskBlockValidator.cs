using FluentValidation;
using ToDoList.ViewModels;

namespace ToDoList.Validators
{
    public class CreateTaskBlockValidator : AbstractValidator<CreateTaskBlockViewModel>
    {
        public CreateTaskBlockValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithName("Name").WithMessage("Name is necessary")
                .MinimumLength(1).WithName("Name").WithMessage("Name must be bigger than 1 symb");
        }
    }
}
