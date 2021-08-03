namespace BlueBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "TheaterId", "dbo.Theatre");
            DropIndex("dbo.Movie", new[] { "TheaterId" });
            AlterColumn("dbo.Movie", "TheaterId", c => c.Int());
            CreateIndex("dbo.Movie", "TheaterId");
            AddForeignKey("dbo.Movie", "TheaterId", "dbo.Theatre", "TheatreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "TheaterId", "dbo.Theatre");
            DropIndex("dbo.Movie", new[] { "TheaterId" });
            AlterColumn("dbo.Movie", "TheaterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movie", "TheaterId");
            AddForeignKey("dbo.Movie", "TheaterId", "dbo.Theatre", "TheatreID", cascadeDelete: true);
        }
    }
}
