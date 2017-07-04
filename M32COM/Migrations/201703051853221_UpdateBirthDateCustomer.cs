namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDateTime", c => c.DateTime(nullable: false));
        }
    }
}
