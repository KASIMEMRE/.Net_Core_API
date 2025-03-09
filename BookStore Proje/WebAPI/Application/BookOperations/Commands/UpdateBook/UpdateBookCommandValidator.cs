using FluentValidation;

namespace WebAPI.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
        }
    }
}