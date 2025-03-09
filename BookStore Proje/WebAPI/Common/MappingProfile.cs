using AutoMapper;
using WebAPI.Application.GenreOperations.Queries;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.BookOperations.CreateBooks;
using WebAPI.BookOperations.GetBookDetailQuery;
using WebAPI.BookOperations.GetBooks;
using WebAPI.Entities;
using static WebAPI.BookOperations.CreateBooks.CreateBookCommand;

namespace WebAPI.Comman
{
    public class MappingProfile:Profile{
        public MappingProfile(){
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,GetBookDetailQuery>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();

        }
    }
}