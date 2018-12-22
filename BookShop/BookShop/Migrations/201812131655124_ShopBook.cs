namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShopBooks",
                c => new
                    {
                        ShopId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShopId, t.BookId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopBooks", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.ShopBooks", "BookId", "dbo.Books");
            DropIndex("dbo.ShopBooks", new[] { "BookId" });
            DropIndex("dbo.ShopBooks", new[] { "ShopId" });
            DropTable("dbo.ShopBooks");
        }
    }
}
