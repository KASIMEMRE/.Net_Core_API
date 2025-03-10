using System.Data;
using FluentValidation;

namespace WebAPI.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {

        public CreateGenreCommandValidator(){
            RuleFor(command=>command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}