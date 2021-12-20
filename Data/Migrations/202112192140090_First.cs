namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CV",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Competence = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CV", "UserId", "dbo.User");
            DropIndex("dbo.CV", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.CV");
        }
    }
}
