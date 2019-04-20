using E_Auction.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionFileMeta> AuctionFiles { get; set; }
        public DbSet<AuctionCategory> AuctionCategories { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserPosition>()
                .HasMany(p => p.Users)
                .WithRequired(p => p.Position)
                .HasForeignKey(p => p.PositionId);

            modelBuilder.Entity<Organization>()
                .HasMany(p => p.Users)
                .WithRequired(p => p.Organization)
                .HasForeignKey(p => p.OrganizationId);

            modelBuilder
                .Entity<Organization>()
                .HasMany(p => p.Auctions)
                .WithRequired(p => p.Organization)
                .HasForeignKey(p => p.OrganizationId);

            modelBuilder
                .Entity<Organization>()
                .HasMany(p => p.Bids)
                .WithRequired(p => p.Organization)
                .HasForeignKey(p => p.OrganizationId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Auction>()
                .HasRequired(p => p.Category)
                .WithMany(p => p.Auctions)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder
                .Entity<Auction>()
                .HasMany(p => p.Files)
                .WithRequired(p => p.Auction)
                .HasForeignKey(p => p.AuctionId);
            modelBuilder
                .Entity<Auction>()
                .HasMany(p => p.Bids)
                .WithRequired(p => p.Auction)
                .HasForeignKey(p => p.AuctionId);                

            base.OnModelCreating(modelBuilder);
        }

        public AplicationDbContext() : base("E-AuctionConnectionString")
        {

        }
    }
}
