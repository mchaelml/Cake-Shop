namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTotalPriceToOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "totalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "totalPrice");
        }
    }
}
