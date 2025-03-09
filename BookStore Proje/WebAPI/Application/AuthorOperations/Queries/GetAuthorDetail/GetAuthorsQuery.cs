using System.Runtime.CompilerServices;
using AutoMapper;
using WebAPI.DBOperations;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorsQueryDetail{
        public int AuthorId{get; set;}
        private readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorsQueryDetail(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle(){
            var author = _context.Authors.SingleOrDefault(x=>x.IsActive && x.Id ==AuthorId);
            AuthorDetailViewModel returnObj = _mapper.Map<AuthorDetailViewModel>(author);
            if(author is null)
            throw new InvalidOperationException("Yazar Türü Bulunamadı");
            return returnObj;
            
        }

    }

    public class AuthorDetailViewModel{
        public int Id {get;set;}
        public string Name {get; set;}
    }
}