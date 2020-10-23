namespace FluentTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DatePosted = c.DateTime(nullable: false),
                        Content = c.String(),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Description = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.User_Friends",
                c => new
                    {
                        Dev_ID = c.Int(nullable: false),
                        Friend_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dev_ID, t.Friend_ID })
                .ForeignKey("dbo.Users", t => t.Dev_ID)
                .ForeignKey("dbo.Users", t => t.Friend_ID)
                .Index(t => t.Dev_ID)
                .Index(t => t.Friend_ID);
            
            CreateTable(
                "dbo.User_Requests",
                c => new
                    {
                        Dev_ID = c.Int(nullable: false),
                        Requester_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dev_ID, t.Requester_ID })
                .ForeignKey("dbo.Users", t => t.Dev_ID)
                .ForeignKey("dbo.Users", t => t.Requester_ID)
                .Index(t => t.Dev_ID)
                .Index(t => t.Requester_ID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Developers", "ID", "dbo.Users");
            DropForeignKey("dbo.Companies", "ID", "dbo.Users");
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.User_Requests", "Requester_ID", "dbo.Users");
            DropForeignKey("dbo.User_Requests", "Dev_ID", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_ID", "dbo.Users");
            DropForeignKey("dbo.User_Friends", "Friend_ID", "dbo.Users");
            DropForeignKey("dbo.User_Friends", "Dev_ID", "dbo.Users");
            DropIndex("dbo.Developers", new[] { "ID" });
            DropIndex("dbo.Companies", new[] { "ID" });
            DropIndex("dbo.User_Requests", new[] { "Requester_ID" });
            DropIndex("dbo.User_Requests", new[] { "Dev_ID" });
            DropIndex("dbo.User_Friends", new[] { "Friend_ID" });
            DropIndex("dbo.User_Friends", new[] { "Dev_ID" });
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropIndex("dbo.Posts", new[] { "User_ID" });
            DropTable("dbo.Developers");
            DropTable("dbo.Companies");
            DropTable("dbo.User_Requests");
            DropTable("dbo.User_Friends");
            DropTable("dbo.Jobs");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
        }
    }
}
