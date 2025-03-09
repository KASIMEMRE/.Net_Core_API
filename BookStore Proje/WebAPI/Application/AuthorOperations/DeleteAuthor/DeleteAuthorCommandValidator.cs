using FluentValidation;
using WebAPI.DBOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator(){
            RuleFor(command=>command.AuthorId).GreaterThan(0);
        }
    }
}