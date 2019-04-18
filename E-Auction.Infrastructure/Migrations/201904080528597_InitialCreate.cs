namespace E_Auction.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionFileMetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        AuctionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .Index(t => t.AuctionId);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ShippingAddress = c.String(),
                        Conditions = c.String(),
                        StartPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Step = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryAuctions", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrganizationId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .Index(t => t.AuctionId);
            
            CreateTable(
                "dbo.CategoryAuctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        IdentificationNumber = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        OrganizationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationTypeId, cascadeDelete: true)
                .Index(t => t.OrganizationTypeId);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "OrganizationTypeId", "dbo.OrganizationTypes");
            DropForeignKey("dbo.AuctionFileMetas", "AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.Auctions", "CategoryId", "dbo.CategoryAuctions");
            DropForeignKey("dbo.Bids", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.Organizations", new[] { "OrganizationTypeId" });
            DropIndex("dbo.Bids", new[] { "AuctionId" });
            DropIndex("dbo.Auctions", new[] { "OrganizationId" });
            DropIndex("dbo.Auctions", new[] { "CategoryId" });
            DropIndex("dbo.AuctionFileMetas", new[] { "AuctionId" });
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.Organizations");
            DropTable("dbo.CategoryAuctions");
            DropTable("dbo.Bids");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionFileMetas");
        }
    }
}
