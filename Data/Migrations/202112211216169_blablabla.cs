namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blablabla : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CVs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CVs", new[] { "User_Id" });
            DropTable("dbo.CVs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Competence = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CVs", "User_Id");
            AddForeignKey("dbo.CVs", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
