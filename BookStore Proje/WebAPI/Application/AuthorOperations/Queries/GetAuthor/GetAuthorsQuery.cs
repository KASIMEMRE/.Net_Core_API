using AutoMapper;
using WebAPI.DBOperations;
using System.Linq;
using System.Collections.Generic;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorsQuery{
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle(){
            var authors = _context.Authors.Where(x=>x.IsActive).OrderBy(x=>x.Id);
            List<AuthorsViewModel> returnObj = _mapper.Map<List<AuthorsViewModel>>(authors);
            return returnObj;
        }
    }
    public class AuthorsViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
    