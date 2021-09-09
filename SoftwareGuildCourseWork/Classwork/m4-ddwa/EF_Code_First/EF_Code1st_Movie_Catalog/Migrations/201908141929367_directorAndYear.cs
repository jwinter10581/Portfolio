namespace EF_Code1st_Movie_Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class directorAndYear : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            AddColumn("dbo.Movies", "ReleaseYear", c => c.DateTime());
            AddColumn("dbo.Movies", "DirectorId", c => c.Int());
            CreateIndex("dbo.Movies", "DirectorId");
            AddForeignKey("dbo.Movies", "DirectorId", "dbo.Directors", "DirectorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropColumn("dbo.Movies", "DirectorId");
            DropColumn("dbo.Movies", "ReleaseYear");
            DropTable("dbo.Directors");
        }
    }
}
