using FluentValidation;
using ToDoList.ViewModels;

namespace ToDoList.Validators
{
    public class EditTaskBlockValidator : AbstractValidator<EditTaskBlockViewModel>
    {
        public EditTaskBlockValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id cannot be negative");

            RuleFor(p => p.Name)
                .NotEmpty().WithName("Name").WithMessage("Name is necessary")
                .MinimumLength(1).WithName("Name").WithMessage("Name must be bigger than 1 symb");
        }
    }
}
