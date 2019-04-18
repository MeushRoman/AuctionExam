namespace E_Auction.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdddedbindingbetweenOrganizationandBid2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Bids", "OrganizationId");
            AddForeignKey("dbo.Bids", "OrganizationId", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Bids", new[] { "OrganizationId" });
        }
    }
}
