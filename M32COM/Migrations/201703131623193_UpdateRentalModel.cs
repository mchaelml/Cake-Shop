namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRentalModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropIndex("dbo.Rentals", new[] { "movie_Id" });
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            CreateIndex("dbo.Rentals", "movie_Id");
            CreateIndex("dbo.Rentals", "customer_Id");
        }
    }
}
