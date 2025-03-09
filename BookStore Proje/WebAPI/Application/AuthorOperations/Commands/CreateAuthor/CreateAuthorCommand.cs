using WebAPI.DBOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand{
        public CreateAuthorModel Model{get; set;}
        private readonly BookStoreDbContext _context;

        public CreateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var author = _context.Authors.SingleOrDefault(x=>x.Name==Model.Name);
            if(author is not null)
            throw new InvalidCastException("Yazar türü zaten mevcut");

            author = new Author();
            author.Name = Model.Name;
            _context.Authors.Add(author);
            _context.SaveChanges();
        }



    }
    public class CreateAuthorModel{
            public string Name {get; set;}
    }
   
}