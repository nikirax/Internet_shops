namespace Internet_shops.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ValueUnit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ValueUnit", c => c.Double(nullable: false));
        }
    }
}
