using System.Data;
using FluentValidation;

namespace WebAPI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenresQueryDetailValidator : AbstractValidator<GetGenresQueryDetail>
    {

        public GetGenresQueryDetailValidator(){
            RuleFor(query=>query.GenreId).GreaterThan(0);
        }
    }
}