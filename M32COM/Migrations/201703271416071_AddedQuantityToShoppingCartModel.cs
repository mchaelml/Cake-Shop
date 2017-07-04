namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantityToShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCards", "quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCards", "quantity");
        }
    }
}
