using System.Data;
using FluentValidation;

namespace WebAPI.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {

        public CreateAuthorCommandValidator(){
            RuleFor(command=>command.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}