namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cvuserlink : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cvs", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.Cvs");
            AddColumn("dbo.Cvs", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cvs", "ApplicationUserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Cvs", "Id");
            CreateIndex("dbo.Cvs", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cvs", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.Cvs");
            AlterColumn("dbo.Cvs", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Cvs", "Id");
            AddPrimaryKey("dbo.Cvs", "ApplicationUserId");
            CreateIndex("dbo.Cvs", "ApplicationUserId");
        }
    }
}
