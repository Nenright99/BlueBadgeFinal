namespace BlueBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "ID", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "ID" });
            AlterColumn("dbo.Review", "ID", c => c.Int());
            CreateIndex("dbo.Review", "ID");
            AddForeignKey("dbo.Review", "ID", "dbo.Movie", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "ID", "dbo.Movie");
            DropIndex("dbo.Review", new[] { "ID" });
            AlterColumn("dbo.Review", "ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "ID");
            AddForeignKey("dbo.Review", "ID", "dbo.Movie", "ID", cascadeDelete: true);
        }
    }
}
