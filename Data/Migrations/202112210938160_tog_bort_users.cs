namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tog_bort_users : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CVs", "UserId", "dbo.Users");
            DropIndex("dbo.CVs", new[] { "UserId" });
            AddColumn("dbo.CVs", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "PrivateAccount", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            CreateIndex("dbo.CVs", "User_Id");
            AddForeignKey("dbo.CVs", "User_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        ImagePath = c.String(),
                        Address = c.String(),
                        PrivateUser = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.CVs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CVs", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "PrivateAccount");
            DropColumn("dbo.CVs", "User_Id");
            CreateIndex("dbo.CVs", "UserId");
            AddForeignKey("dbo.CVs", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
