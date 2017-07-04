namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "orderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "orderDate");
        }
    }
}
