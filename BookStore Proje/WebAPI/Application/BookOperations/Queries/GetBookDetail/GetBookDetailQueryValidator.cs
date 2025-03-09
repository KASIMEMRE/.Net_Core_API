using FluentValidation;

namespace WebAPI.BookOperations.GetBookDetailQuery
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(query=>query.BookId).GreaterThan(0);
            
        }


    }
}