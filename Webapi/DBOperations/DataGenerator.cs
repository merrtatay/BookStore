using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Webapi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider servciceProvider)
        {
            using( var context = new BookStoreDbContext(servciceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any()){
                    return;
                }

                context.Books.AddRange(
            new Book {
                
                Title="Lean Startup",
                GenreId=1,
                PageCount=200,
                PublishTime = new DateTime(2001,05,23)
            },
            new Book {
                
                Title="Herland",
                GenreId=2,
                PageCount=250,
                PublishTime = new DateTime(2010,05,23)
            },
            new Book {
                
                Title="Dune",
                GenreId=3,
                PageCount=540,
                PublishTime = new DateTime(2001,12,21)
            }
            );
            context.SaveChanges();
                
            }
        }
    }

}