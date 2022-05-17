namespace Internet_shops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CardClients", "CVV", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CardClients", "CVV");
        }
    }
}
