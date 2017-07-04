namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieGenreIdToMovieModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenre_Id" });
            RenameColumn(table: "dbo.Movies", name: "MovieGenre_Id", newName: "MovieGenreId");
            AlterColumn("dbo.Movies", "MovieGenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreId");
            AddForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreId", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "MovieGenreId" });
            AlterColumn("dbo.Movies", "MovieGenreId", c => c.Byte());
            RenameColumn(table: "dbo.Movies", name: "MovieGenreId", newName: "MovieGenre_Id");
            CreateIndex("dbo.Movies", "MovieGenre_Id");
            AddForeignKey("dbo.Movies", "MovieGenre_Id", "dbo.MovieGenres", "Id");
        }
    }
}
