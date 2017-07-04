namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cakesImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cakes", "imageSource", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cakes", "imageSource");
        }
    }
}
