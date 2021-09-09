namespace EF_Code1st_Movie_Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        RatingId = c.Int(),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.GenreId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "RatingId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
