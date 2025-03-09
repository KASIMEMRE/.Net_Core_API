using Microsoft.EntityFrameworkCore;
using WebAPI.DBOperations;
using WebAPI.Entities;

namespace WebAPI.DataGenerator
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return; 
                }
                context.Genres.AddRange(
                    new Genre{
                        Name="Personal Growth"
                    },
                     new Genre{
                        Name="Science Fiction"
                    },
                     new Genre{
                        Name="Romance"
                    }
                );
                context.Authors.AddRange(
                    new Author{
                        Name="Cemil Saatçi"
                    },
                    new Author{
                        Name="Mücahit Ekiz"
                    },
                    new Author{
                        Name="Furkan MUM"
                    }
                );
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Küçük Prens",
                        GenreId = 1,
                        PageCount = 80,
                        PublicDate = new DateTime(2011, 4, 23)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Beyaz Kurt",
                        GenreId = 2,
                        PageCount = 200,
                        PublicDate = new DateTime(2007, 2, 2)
                    },
                    new Book
                    {
                       //Id = 3,
                        Title = "Kürk Mantolu Madonna",
                        GenreId = 2,
                        PageCount = 180,
                        PublicDate = new DateTime(2012, 8, 12)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}



