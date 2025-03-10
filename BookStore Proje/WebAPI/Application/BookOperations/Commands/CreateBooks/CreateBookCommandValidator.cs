using FluentValidation;

namespace WebAPI.BookOperations.CreateBooks
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {

        public CreateBookCommandValidator()
        {
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            RuleFor(command=>command.Model.PageCount).GreaterThan(0);
            RuleFor(command=>command.Model.PublicDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.Model.Title).NotEmpty().MinimumLength(4);
        }
        
    }
}