namespace E_Auction.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrganizationInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Email", c => c.String());
            AddColumn("dbo.Organizations", "Adress", c => c.String());
            AddColumn("dbo.Organizations", "PhoneNumber", c => c.String());
            AddColumn("dbo.Organizations", "LinkToSite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "LinkToSite");
            DropColumn("dbo.Organizations", "PhoneNumber");
            DropColumn("dbo.Organizations", "Adress");
            DropColumn("dbo.Organizations", "Email");
        }
    }
}
