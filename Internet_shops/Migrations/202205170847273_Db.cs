namespace Internet_shops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardClients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        Date = c.String(),
                        Client_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FIO = c.String(),
                        Age = c.Byte(nullable: false),
                        ShopCartId = c.Guid(nullable: false),
                        IsRegular = c.Boolean(nullable: false),
                        TownClient_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.TownClient_Id)
                .Index(t => t.TownClient_Id);
            
            CreateTable(
                "dbo.ShopCarts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AllPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountProducts = c.Byte(nullable: false),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitMeasurement = c.String(),
                        ValueUnit = c.Double(nullable: false),
                        ShopCart_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShopCarts", t => t.ShopCart_Id)
                .Index(t => t.ShopCart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "TownClient_Id", "dbo.Cities");
            DropForeignKey("dbo.Products", "ShopCart_Id", "dbo.ShopCarts");
            DropForeignKey("dbo.ShopCarts", "Id", "dbo.Clients");
            DropForeignKey("dbo.CardClients", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Products", new[] { "ShopCart_Id" });
            DropIndex("dbo.ShopCarts", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "TownClient_Id" });
            DropIndex("dbo.CardClients", new[] { "Client_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.ShopCarts");
            DropTable("dbo.Clients");
            DropTable("dbo.Cities");
            DropTable("dbo.CardClients");
        }
    }
}
