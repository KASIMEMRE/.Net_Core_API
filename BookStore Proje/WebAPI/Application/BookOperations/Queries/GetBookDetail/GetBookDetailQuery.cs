using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Comman;
using WebAPI.DBOperations;


namespace WebAPI.BookOperations.GetBookDetailQuery
{

    
    public class GetBookDetailQuery{
        

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId {get;set;}
        public object Genre { get; internal set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle(){
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if(book is null)
            throw new InvalidOperationException("Kitap Yok");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            //new BookDetailViewModel();
            // vm.Title=book.Title;
            // vm.PageCount=book.PageCount;
            // vm.PublicDate=book.PublicDate.Date.ToString("dd/mm/yyy");
            // vm.GenreId=((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }

    public class BookDetailViewModel{
        public string Title { get; set; }
        public string GenreId { get; set; }
        public int PageCount { get; set; }
        public string PublicDate { get; set; }
    }
}