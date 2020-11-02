namespace FluentTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        Password = c.String(),
                        CurrentPosition = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.DeveloperContactInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeveloperID = c.Int(nullable: false),
                        Phone = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DeveloperFollows",
                c => new
                    {
                        Developer_ID = c.Int(nullable: false),
                        Developer2_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Developer_ID, t.Developer2_ID })
                .ForeignKey("dbo.Developer", t => t.Developer_ID)
                .ForeignKey("dbo.Developer", t => t.Developer2_ID)
                .Index(t => t.Developer_ID)
                .Index(t => t.Developer2_ID);
            
            CreateTable(
                "dbo.CompanyFollows",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Company_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Company_ID })
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Companies", t => t.Company_ID)
                .Index(t => t.User_ID)
                .Index(t => t.Company_ID);
            
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
                "dbo.Developer",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ContactInfo_ID = c.Int(),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .ForeignKey("dbo.DeveloperContactInfoes", t => t.ContactInfo_ID)
                .Index(t => t.ID)
                .Index(t => t.ContactInfo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Developer", "ContactInfo_ID", "dbo.DeveloperContactInfoes");
            DropForeignKey("dbo.Developer", "ID", "dbo.Users");
            DropForeignKey("dbo.Companies", "ID", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_ID", "dbo.Users");
            DropForeignKey("dbo.CompanyFollows", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.CompanyFollows", "User_ID", "dbo.Users");
            DropForeignKey("dbo.DeveloperFollows", "Developer2_ID", "dbo.Developer");
            DropForeignKey("dbo.DeveloperFollows", "Developer_ID", "dbo.Developer");
            DropForeignKey("dbo.Jobs", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Developer", new[] { "ContactInfo_ID" });
            DropIndex("dbo.Developer", new[] { "ID" });
            DropIndex("dbo.Companies", new[] { "ID" });
            DropIndex("dbo.CompanyFollows", new[] { "Company_ID" });
            DropIndex("dbo.CompanyFollows", new[] { "User_ID" });
            DropIndex("dbo.DeveloperFollows", new[] { "Developer2_ID" });
            DropIndex("dbo.DeveloperFollows", new[] { "Developer_ID" });
            DropIndex("dbo.Posts", new[] { "User_ID" });
            DropIndex("dbo.Jobs", new[] { "CompanyID" });
            DropTable("dbo.Developer");
            DropTable("dbo.Companies");
            DropTable("dbo.CompanyFollows");
            DropTable("dbo.DeveloperFollows");
            DropTable("dbo.DeveloperContactInfoes");
            DropTable("dbo.Posts");
            DropTable("dbo.Jobs");
            DropTable("dbo.Users");
        }
    }
}
