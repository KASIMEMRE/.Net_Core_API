using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Comman;
using WebAPI.DBOperations;
using WebAPI.Entities;


namespace WebAPI.BookOperations.GetBooks
{
    public class GetBooksQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle(){
            var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            // foreach (var book in bookList)
            // {
            //     vm.Add(new BooksViewModel(){
            //         Title=book.Title,
            //         Genre=((GenreEnum)book.GenreId).ToString(),
            //         PublicDate=book.PublicDate.Date.ToString("dd/mm/yyy"),
            //         PageCount=book.PageCount
            //     });
            //}
            return vm;
        }
    }

    public class BooksViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublicDate { get; set; }
        public string Genre { get; set; }
    }
}