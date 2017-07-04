namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBCheck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDateTime", c => c.DateTime());
        }
    }
}
