namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cvs", new[] { "ApplicationUserId" });
            RenameColumn(table: "dbo.Cvs", name: "ApplicationUserId", newName: "UserId");
            DropPrimaryKey("dbo.Cvs");
            AlterColumn("dbo.Cvs", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Cvs", "UserId");
            CreateIndex("dbo.Cvs", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Cvs", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cvs", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Cvs", new[] { "UserId" });
            DropPrimaryKey("dbo.Cvs");
            AlterColumn("dbo.Cvs", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Cvs", "Id");
            RenameColumn(table: "dbo.Cvs", name: "UserId", newName: "ApplicationUserId");
            CreateIndex("dbo.Cvs", "ApplicationUserId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
    }
}
