namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "User", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "User");
        }
    }
}
