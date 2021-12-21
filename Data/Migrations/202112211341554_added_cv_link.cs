namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_cv_link : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Competence = c.String(),
                        Education = c.String(),
                        Experience = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cvs", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cvs", new[] { "ApplicationUserId" });
            DropTable("dbo.Cvs");
        }
    }
}
