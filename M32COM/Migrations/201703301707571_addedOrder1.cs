namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrder1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        address = c.String(nullable: false),
                        postCode = c.String(nullable: false),
                        name = c.String(nullable: false),
                        surname = c.String(nullable: false),
                        creditCardNumber = c.String(nullable: false),
                        expDate = c.DateTime(nullable: false),
                        cardName = c.String(nullable: false),
                        city = c.String(nullable: false),
                        ccv = c.Int(nullable: false),
                        card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingCards", t => t.card_Id, cascadeDelete: true)
                .Index(t => t.card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "card_Id", "dbo.ShoppingCards");
            DropIndex("dbo.Orders", new[] { "card_Id" });
            DropTable("dbo.Orders");
        }
    }
}
