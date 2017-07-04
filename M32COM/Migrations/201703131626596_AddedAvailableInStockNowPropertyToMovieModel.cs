namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvailableInStockNowPropertyToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableInStockNow", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET AvailableInStockNow = InStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableInStockNow");
        }
    }
}
