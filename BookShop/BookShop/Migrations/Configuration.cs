namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookShop.DTOs;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShop.Models.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookShop.Models.BookShopContext context)
        {
            context.Authors.AddOrUpdate(x => x.Id,
                new Models.Author() { Id = 1, Name = "Norton" },
                new Models.Author() { Id = 2, Name = "Osborn" },
                new Models.Author() { Id = 3, Name = "Wellingtone" }
                );
            context.Books.AddOrUpdate(x => x.Id,
                new Models.Book() { Id = 1,
                    Title = "First",
                    Genre = "Fiction",
                    Price = 9.99M, Year = 1955,
                    AuthorId = 1 },
                 new Models.Book()
                 {
                     Id = 2,
                     Title = "Second",
                     Genre = "Historical",
                     Price = 5.99M,
                     Year = 1940,
                     AuthorId = 2
                 },
                  new Models.Book()
                  {
                      Id = 3,
                      Title = "Third",
                      Genre = "Fiction",
                      Price = 6.44M,
                      Year = 1970,
                      AuthorId = 3
                  }
                  
                  );
            context.Shops.AddOrUpdate(x => x.Id,
               new Models.Shop() { Id = 1, Name = "Southern", City = "Boston" },
               new Models.Shop() { Id = 2, Name = "Western", City = "Springfield" },
               new Models.Shop() { Id = 3, Name = "Union", City = "South Park" }
               );

            context.ShopBooks.AddOrUpdate(x => x.BookId,
              new Models.ShopBook() { BookId = 1, ShopId = 1, Quantity = 10},
              new Models.ShopBook() { BookId = 2, ShopId = 2, Quantity = 20 },
              new Models.ShopBook() { BookId = 3, ShopId = 3, Quantity = 30}
              );


        }
    }
}
