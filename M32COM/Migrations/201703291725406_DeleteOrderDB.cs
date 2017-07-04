namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOrderDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
