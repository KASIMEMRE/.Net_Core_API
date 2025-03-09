using System.Data;
using FluentValidation;

namespace WebAPI.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {

        public UpdateAuthorCommandValidator(){
            RuleFor(command=>command.Model.Name).MinimumLength(4).When(x=>x.Model.Name.Trim() != string.Empty);
        }
        
    }
}