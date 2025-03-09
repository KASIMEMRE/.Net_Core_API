using System.Data;
using FluentValidation;

namespace WebAPI.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {

        public UpdateGenreCommandValidator(){
            RuleFor(command=>command.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim() != string.Empty);
        }
        
    }
}