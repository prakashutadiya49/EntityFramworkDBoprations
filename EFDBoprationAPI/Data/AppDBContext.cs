using DbOperationsWithEFCoreApp.Data;
using Microsoft.EntityFrameworkCore;

/*
 * Code which return here is evecute always if we use Entity frameWork 
 * and if we update Database many time than not every time add only add one time when model is created.
 * 
 * other Ways:
 * 
 * 1.write sql query in one sql script file and execute this file.
 * 2.create one method which insert record when appliATION RUN
 * 3.add record manually on sql server
 * 4. use json file in appconfigurejson to add data.
 */
namespace EFDBoprationAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        //add defult Data in Currency Master table.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //for Currency class:

            modelBuilder.Entity<Currency>().HasData(
            new Currency { Id = 1, Title = "USD", Description = "United States Dollar" },
            new Currency { Id = 2, Title = "EUR", Description = "Euro" },
            new Currency { Id = 3, Title = "JPY", Description = "Japanese Yen" },
            new Currency { Id = 4, Title = "GBP", Description = "British Pound Sterling" },
            new Currency { Id = 5, Title = "AUD", Description = "Australian Dollar" },
            new Currency { Id = 6, Title = "CAD", Description = "Canadian Dollar" },
            new Currency { Id = 7, Title = "CHF", Description = "Swiss Franc" },
            new Currency { Id = 8, Title = "CNY", Description = "Chinese Yuan" },
            new Currency { Id = 9, Title = "SEK", Description = "Swedish Krona" },
            new Currency { Id = 10, Title = "NZD", Description = "New Zealand Dollar" },
            new Currency { Id = 11, Title = "INR", Description = "Indian Rupee" }
            );

            //for Language class:

            modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Title = "English", Description = "English language" },
            new Language { Id = 2, Title = "Spanish", Description = "Spanish language" },
            new Language { Id = 3, Title = "French", Description = "French language" },
            new Language { Id = 4, Title = "German", Description = "German language" },
            new Language { Id = 5, Title = "Chinese", Description = "Chinese language" },
            new Language { Id = 6, Title = "Japanese", Description = "Japanese language" },
            new Language { Id = 7, Title = "Russian", Description = "Russian language" },
            new Language { Id = 8, Title = "Arabic", Description = "Arabic language" },
            new Language { Id = 9, Title = "Portuguese", Description = "Portuguese language" },
            new Language { Id = 10, Title = "Italian", Description = "Italian language" }
            );

        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BookPrice> BookPrice { get; set; }

        public DbSet<Currency> Currency { get; set; }


    }
}
