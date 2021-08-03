namespace BlueBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        MovieReview = c.Int(nullable: false),
                        TheatreReview = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        ReviewId = c.Int(nullable: false),
                        Theatre_ID = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Movie", t => t.MovieReview, cascadeDelete: true)
                .ForeignKey("dbo.Theatre", t => t.Theatre_ID)
                .Index(t => t.MovieReview)
                .Index(t => t.Theatre_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "Theatre_ID", "dbo.Theatre");
            DropForeignKey("dbo.Review", "MovieReview", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "Theatre_ID" });
            DropIndex("dbo.Review", new[] { "MovieReview" });
            DropTable("dbo.Review");
        }
    }
}
