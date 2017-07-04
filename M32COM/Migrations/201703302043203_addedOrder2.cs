namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrder2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "expMonth", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "expYear", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "expDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "expDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "expYear");
            DropColumn("dbo.Orders", "expMonth");
        }
    }
}
