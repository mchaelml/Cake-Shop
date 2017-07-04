namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cakes", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Cakes", "Customer_Id");
            AddForeignKey("dbo.Cakes", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cakes", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Cakes", new[] { "Customer_Id" });
            DropColumn("dbo.Cakes", "Customer_Id");
        }
    }
}
