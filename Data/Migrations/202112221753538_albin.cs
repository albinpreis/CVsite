namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectApplicationUsers1", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers1", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectApplicationUsers1", new[] { "ApplicationUserId" });
            DropIndex("dbo.ProjectApplicationUsers1", new[] { "ProjectId" });
            DropTable("dbo.ProjectApplicationUsers1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectApplicationUsers1",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.ProjectId });
            
            CreateIndex("dbo.ProjectApplicationUsers1", "ProjectId");
            CreateIndex("dbo.ProjectApplicationUsers1", "ApplicationUserId");
            AddForeignKey("dbo.ProjectApplicationUsers1", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectApplicationUsers1", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
