using System.Data;
using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorsQueryDetailValidator : AbstractValidator<GetAuthorsQueryDetail>
    {

        public GetAuthorsQueryDetailValidator(){
            RuleFor(query=>query.AuthorId).GreaterThan(0);
        }
    }
}