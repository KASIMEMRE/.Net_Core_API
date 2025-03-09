using FluentValidation;
using WebAPI.DBOperations;
using WebAPI.Entities;

namespace WebAPI.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator(){
            RuleFor(command=>command.GenreId).GreaterThan(0);
        }
    }
}