namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "card_Id", "dbo.ShoppingCards");
            DropIndex("dbo.Orders", new[] { "card_Id" });
            AddColumn("dbo.ShoppingCards", "Order_Id", c => c.Int());
            CreateIndex("dbo.ShoppingCards", "Order_Id");
            AddForeignKey("dbo.ShoppingCards", "Order_Id", "dbo.Orders", "Id");
            DropColumn("dbo.Orders", "card_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "card_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.ShoppingCards", "Order_Id", "dbo.Orders");
            DropIndex("dbo.ShoppingCards", new[] { "Order_Id" });
            DropColumn("dbo.ShoppingCards", "Order_Id");
            CreateIndex("dbo.Orders", "card_Id");
            AddForeignKey("dbo.Orders", "card_Id", "dbo.ShoppingCards", "Id", cascadeDelete: true);
        }
    }
}
