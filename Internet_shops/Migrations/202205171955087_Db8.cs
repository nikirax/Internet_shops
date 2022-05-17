namespace Internet_shops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "ShopCartId", c => c.String());
            AlterColumn("dbo.ShopCarts", "ClientId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShopCarts", "ClientId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Clients", "ShopCartId", c => c.Guid(nullable: false));
        }
    }
}
