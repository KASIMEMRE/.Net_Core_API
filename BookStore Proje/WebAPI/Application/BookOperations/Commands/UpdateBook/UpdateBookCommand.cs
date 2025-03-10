using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Comman;
using WebAPI.DBOperations;


namespace WebAPI.BookOperations.UpdateBook{
    public class UpdateBookCommand{
        public updatedBookModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public int BookId{get;set;}
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
             var book = _context.Books.SingleOrDefault(x=> x.Id==BookId);
            if(book is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _context.SaveChanges();
        }
        public class updatedBookModel{
            public string Title { get; set; }
            public int GenreId { get; set; }

            public static implicit operator updatedBookModel(UpdateBookCommand v)
            {
                throw new NotImplementedException();
            }
        }
    }
}