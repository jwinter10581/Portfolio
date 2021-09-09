namespace EF_Code1st_Movie_Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteDirectorAndYear : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropColumn("dbo.Movies", "ReleaseYear");
            DropColumn("dbo.Movies", "DirectorId");
            DropTable("dbo.Directors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            AddColumn("dbo.Movies", "DirectorId", c => c.Int());
            AddColumn("dbo.Movies", "ReleaseYear", c => c.DateTime());
            CreateIndex("dbo.Movies", "DirectorId");
            AddForeignKey("dbo.Movies", "DirectorId", "dbo.Directors", "DirectorId");
        }
    }
}
