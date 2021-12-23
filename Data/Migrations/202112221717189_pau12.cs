namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pau12 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ProjectApplicationUsers1",
            //    c => new
            //        {
            //            ApplicationUserId = c.String(nullable: false, maxLength: 128),
            //            ProjectId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ApplicationUserId, t.ProjectId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
            //    .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
            //    .Index(t => t.ApplicationUserId)
            //    .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectApplicationUsers1", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectApplicationUsers1", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectApplicationUsers1", new[] { "ProjectId" });
            DropIndex("dbo.ProjectApplicationUsers1", new[] { "ApplicationUserId" });
            DropTable("dbo.ProjectApplicationUsers1");
        }
    }
}
