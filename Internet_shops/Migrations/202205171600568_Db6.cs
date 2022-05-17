namespace Internet_shops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CardClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ShopCarts", "Id", "dbo.Clients");
            DropForeignKey("dbo.Products", "ShopCart_Id", "dbo.ShopCarts");
            DropIndex("dbo.CardClients", new[] { "Client_Id" });
            DropIndex("dbo.ShopCarts", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "ShopCart_Id" });
            DropPrimaryKey("dbo.CardClients");
            DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.ShopCarts");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.CardClients", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CardClients", "Client_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Cities", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clients", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ShopCarts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Products", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Products", "ShopCart_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.CardClients", "Id");
            AddPrimaryKey("dbo.Cities", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.ShopCarts", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            CreateIndex("dbo.CardClients", "Client_Id");
            CreateIndex("dbo.ShopCarts", "Id");
            CreateIndex("dbo.Products", "ShopCart_Id");
            AddForeignKey("dbo.CardClients", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.ShopCarts", "Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Products", "ShopCart_Id", "dbo.ShopCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ShopCart_Id", "dbo.ShopCarts");
            DropForeignKey("dbo.ShopCarts", "Id", "dbo.Clients");
            DropForeignKey("dbo.CardClients", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Products", new[] { "ShopCart_Id" });
            DropIndex("dbo.ShopCarts", new[] { "Id" });
            DropIndex("dbo.CardClients", new[] { "Client_Id" });
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.ShopCarts");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Cities");
            DropPrimaryKey("dbo.CardClients");
            AlterColumn("dbo.Products", "ShopCart_Id", c => c.Guid());
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.ShopCarts", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Clients", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cities", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.CardClients", "Client_Id", c => c.Guid());
            AlterColumn("dbo.CardClients", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.ShopCarts", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Cities", "Id");
            AddPrimaryKey("dbo.CardClients", "Id");
            CreateIndex("dbo.Products", "ShopCart_Id");
            CreateIndex("dbo.ShopCarts", "Id");
            CreateIndex("dbo.CardClients", "Client_Id");
            AddForeignKey("dbo.Products", "ShopCart_Id", "dbo.ShopCarts", "Id");
            AddForeignKey("dbo.ShopCarts", "Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.CardClients", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
