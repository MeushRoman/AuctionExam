namespace E_Auction.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _090419Fix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoryAuctions", newName: "AuctionCategories");
            AddColumn("dbo.AuctionFileMetas", "ContentAsBase64", c => c.Binary());
            AddColumn("dbo.Auctions", "ShippingConditions", c => c.String());
            AddColumn("dbo.Auctions", "PriceAtStart", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Auctions", "PriceChangeStep", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Auctions", "PriceAtMinimum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Auctions", "FinishDateExpected", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "FinishDateActual", c => c.DateTime());
            AddColumn("dbo.Auctions", "AuctionStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Auctions", "Conditions");
            DropColumn("dbo.Auctions", "StartPrice");
            DropColumn("dbo.Auctions", "Step");
            DropColumn("dbo.Auctions", "MinPrice");
            DropColumn("dbo.Auctions", "FinishDate");
            DropColumn("dbo.Auctions", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auctions", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Auctions", "FinishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Auctions", "MinPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Auctions", "Step", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Auctions", "StartPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Auctions", "Conditions", c => c.String());
            DropColumn("dbo.Auctions", "AuctionStatus");
            DropColumn("dbo.Auctions", "FinishDateActual");
            DropColumn("dbo.Auctions", "FinishDateExpected");
            DropColumn("dbo.Auctions", "PriceAtMinimum");
            DropColumn("dbo.Auctions", "PriceChangeStep");
            DropColumn("dbo.Auctions", "PriceAtStart");
            DropColumn("dbo.Auctions", "ShippingConditions");
            DropColumn("dbo.AuctionFileMetas", "ContentAsBase64");
            RenameTable(name: "dbo.AuctionCategories", newName: "CategoryAuctions");
        }
    }
}
