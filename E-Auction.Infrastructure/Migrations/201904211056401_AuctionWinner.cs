namespace E_Auction.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionWinner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionWinners",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AuctionId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.OrganizationId);
            
            AddColumn("dbo.Bids", "AuctionWin", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionWinners", "Id", "dbo.Auctions");
            DropForeignKey("dbo.AuctionWinners", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.AuctionWinners", new[] { "OrganizationId" });
            DropIndex("dbo.AuctionWinners", new[] { "Id" });
            DropColumn("dbo.Bids", "AuctionWin");
            DropTable("dbo.AuctionWinners");
        }
    }
}
