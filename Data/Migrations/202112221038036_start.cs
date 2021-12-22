namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ApplicationUserProjects", new[] { "ApplicationUserId" });
            DropIndex("dbo.ApplicationUserProjects", new[] { "ProjectId" });
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropTable("dbo.ApplicationUserProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserProjects",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.ProjectId });
            
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropTable("dbo.ProjectApplicationUsers");
            CreateIndex("dbo.ApplicationUserProjects", "ProjectId");
            CreateIndex("dbo.ApplicationUserProjects", "ApplicationUserId");
            AddForeignKey("dbo.ApplicationUserProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserProjects", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
