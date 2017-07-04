namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cakes", "ShoppingCard_Id", "dbo.ShoppingCards");
            DropIndex("dbo.Cakes", new[] { "ShoppingCard_Id" });
            AddColumn("dbo.Movies", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCards", "Name", c => c.String(nullable: false));
            AddColumn("dbo.ShoppingCards", "InStock", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCards", "Calories", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCards", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Cakes", "ShoppingCard_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cakes", "ShoppingCard_Id", c => c.Int());
            DropColumn("dbo.ShoppingCards", "Price");
            DropColumn("dbo.ShoppingCards", "Calories");
            DropColumn("dbo.ShoppingCards", "InStock");
            DropColumn("dbo.ShoppingCards", "Name");
            DropColumn("dbo.Movies", "Quantity");
            CreateIndex("dbo.Cakes", "ShoppingCard_Id");
            AddForeignKey("dbo.Cakes", "ShoppingCard_Id", "dbo.ShoppingCards", "Id");
        }
    }
}
