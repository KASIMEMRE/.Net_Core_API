using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Comman;
using WebAPI.DBOperations;


namespace WebAPI.BookOperations.DeleteBook{
    public class DeleteBookCommand{

        private readonly BookStoreDbContext _dbContext;
        public int BookId{get;set;}

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
             var book = _dbContext.Books.SingleOrDefault(x=> x.Id==BookId);
            if(book is null)
            throw new InvalidOperationException("Silinecek Kitap Bulunamadı");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }
    }
}