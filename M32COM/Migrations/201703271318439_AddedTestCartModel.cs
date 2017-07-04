namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestCartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cake_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cakes", t => t.Cake_Id)
                .Index(t => t.Cake_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCarts", "Cake_Id", "dbo.Cakes");
            DropIndex("dbo.TestCarts", new[] { "Cake_Id" });
            DropTable("dbo.TestCarts");
        }
    }
}
