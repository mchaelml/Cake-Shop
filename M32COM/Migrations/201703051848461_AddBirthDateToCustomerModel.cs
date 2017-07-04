namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDateTime");
        }
    }
}
