namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCakesDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        InStock = c.Int(nullable: false),
                        Calories = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cakes");
        }
    }
}
