namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testarrall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            CreateTable(
                "dbo.ApplicationUserProjects",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.ProjectId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ProjectId);
            
            DropTable("dbo.ProjectApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.Int(nullable: false),
                        Project_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Project_Id });
            
            DropForeignKey("dbo.ApplicationUserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ApplicationUserProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserProjects", new[] { "ProjectId" });
            DropIndex("dbo.ApplicationUserProjects", new[] { "ApplicationUserId" });
            DropTable("dbo.ApplicationUserProjects");
            CreateIndex("dbo.ProjectApplicationUsers", "Project_Id");
            CreateIndex("dbo.ProjectApplicationUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
