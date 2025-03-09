using System.Runtime.CompilerServices;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenresQueryDetail{

        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenresQueryDetail(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle(){
            var genre = _context.Genres.SingleOrDefault(x=>x.IsActive && x.Id == GenreId);
            GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genre);
            if(genre is null)
            throw new InvalidOperationException("Kitap Türü Bulunamadı");
            return returnObj;
        }
    }
    public class GenreDetailViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}