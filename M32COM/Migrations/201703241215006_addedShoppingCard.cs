namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedShoppingCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cakes", "ShoppingCard_Id", c => c.Int());
            CreateIndex("dbo.Cakes", "ShoppingCard_Id");
            AddForeignKey("dbo.Cakes", "ShoppingCard_Id", "dbo.ShoppingCards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cakes", "ShoppingCard_Id", "dbo.ShoppingCards");
            DropIndex("dbo.Cakes", new[] { "ShoppingCard_Id" });
            DropColumn("dbo.Cakes", "ShoppingCard_Id");
            DropTable("dbo.ShoppingCards");
        }
    }
}
