namespace Internet_shops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "TownClient_Id", "dbo.Cities");
            DropIndex("dbo.Clients", new[] { "TownClient_Id" });
            AddColumn("dbo.Clients", "TownClient", c => c.String());
            DropColumn("dbo.Clients", "TownClient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "TownClient_Id", c => c.Guid());
            DropColumn("dbo.Clients", "TownClient");
            CreateIndex("dbo.Clients", "TownClient_Id");
            AddForeignKey("dbo.Clients", "TownClient_Id", "dbo.Cities", "Id");
        }
    }
}
