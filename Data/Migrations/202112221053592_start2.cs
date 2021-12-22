namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.ProjectApplicationUsers", name: "Project_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ProjectApplicationUsers", name: "ApplicationUser_Id", newName: "Project_Id");
            RenameColumn(table: "dbo.ProjectApplicationUsers", name: "__mig_tmp__0", newName: "ApplicationUser_Id");
            DropPrimaryKey("dbo.ProjectApplicationUsers");
            AlterColumn("dbo.ProjectApplicationUsers", "Project_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProjectApplicationUsers", "ApplicationUser_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id", "Project_Id" });
            CreateIndex("dbo.ProjectApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ProjectApplicationUsers", "Project_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.ProjectApplicationUsers");
            AlterColumn("dbo.ProjectApplicationUsers", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProjectApplicationUsers", "Project_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProjectApplicationUsers", new[] { "Project_Id", "ApplicationUser_Id" });
            RenameColumn(table: "dbo.ProjectApplicationUsers", name: "ApplicationUser_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ProjectApplicationUsers", name: "Project_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.ProjectApplicationUsers", name: "__mig_tmp__0", newName: "Project_Id");
            CreateIndex("dbo.ProjectApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ProjectApplicationUsers", "Project_Id");
        }
    }
}
