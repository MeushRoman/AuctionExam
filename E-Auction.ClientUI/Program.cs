using AutoMapper;
using E_Auction.BLL.Mappers;
using E_Auction.BLL.Services;
using E_Auction.Core.DataModels;
using E_Auction.Core.Exceptions;
using E_Auction.Core.ViewModels;
using E_Auction.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mapper.Initialize(p=>
            //{
            //    p.AddProfile<OrganizationProfile>();
            //    p.CreateMap<OpenAuctionRequestVm, Auction>();
            //    p.ValidateInlineMaps = false;
            //});

            //AplicationDbContext dbContext = new AplicationDbContext();

            ////var auctionInfo = (from auction in dbContext.Auctions
            ////                   join organization in dbContext.Organizations
            ////                   on auction.OrganizationId equals organization.Id
            ////                   select new { auction.Description, organization.FullName });

            ////var x = auctionInfo.ToList();

            ////var auctionInfo2 = dbContext.Auctions
            ////    .Select(p => new { p.Description, p.Organization.FullName })
            ////    .ToList();


            ////var bids = dbContext.Bids
            ////    .Where(p => p.AuctionId == auction.Id)
            ////    .ToList();

            ////var bidSum = bids.Sum(p => p.Price);

            AuctionManagementService service = new AuctionManagementService();
            var model = service.GetAuctionInfo();
            foreach (var item in model)
            {
                Console.WriteLine(item.AuctionName);
                Console.WriteLine(item.CreatedByOrganization);

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
