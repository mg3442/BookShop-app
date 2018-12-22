using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class BookShopContext : DbContext
    {
        
    
        public BookShopContext() : base("name=BookShopContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopBook>()
                .HasKey(t => new { t.ShopId, t.BookId });

            modelBuilder.Entity<ShopBook>()
                .HasRequired(t => t.Shop).WithMany(t => t.ShopBooks)

                .HasForeignKey(t => t.ShopId).WillCascadeOnDelete();

            modelBuilder.Entity<ShopBook>()
               .HasRequired(t => t.Book).WithMany(t => t.ShopBooks)
               .HasForeignKey(t => t.BookId).WillCascadeOnDelete();
        }
       
        

    public System.Data.Entity.DbSet<BookShop.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<BookShop.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<BookShop.Models.Shop> Shops { get; set; }
        public System.Data.Entity.DbSet<BookShop.Models.ShopBook> ShopBooks { get; set; }


    }
}
