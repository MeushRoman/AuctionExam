namespace E_Auction.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBidstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "BidStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "BidStatus");
        }
    }
}
