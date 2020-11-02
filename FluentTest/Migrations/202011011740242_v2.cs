namespace FluentTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developer", "Address_StreetName", c => c.String());
            AddColumn("dbo.Developer", "Address_StreetNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Developer", "Address_City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developer", "Address_City");
            DropColumn("dbo.Developer", "Address_StreetNumber");
            DropColumn("dbo.Developer", "Address_StreetName");
        }
    }
}
