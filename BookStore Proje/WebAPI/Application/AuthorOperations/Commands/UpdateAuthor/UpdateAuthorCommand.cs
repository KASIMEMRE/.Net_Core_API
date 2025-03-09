using WebAPI.DBOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand{

        public int AuthorId { get; set;}
        public UpdateAuthorModel Model {get; set;}

        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle(){
            var author = _context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if(author is null)
            throw new InvalidCastException("Yazar türü bulunamadı");

            if(_context.Authors.Any(x=>x.Name.ToLower()==Model.Name.ToLower()&& x.Id != AuthorId));
            throw new InvalidCastException("Aynı isimle YAZAR zaten mevcut");

            author.Name = string.IsNullOrEmpty(Model.Name) == default ? author.Name : Model.Name;
            author.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel{
        public string Name {get; set;}
        public bool IsActive {get; set;}
    }
}