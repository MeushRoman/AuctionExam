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
            //Mapper.Initialize(p =>
            //{
            //    p.AddProfile<OrganizationProfile>();
            //    p.CreateMap<OpenAuctionRequestVm, Auction>();
            //    p.ValidateInlineMaps = false;
            //});

            //AplicationDbContext dbContext = new AplicationDbContext();

            //var auctionInfo = (from auction in dbContext.Auctions
            //                   join organization in dbContext.Organizations
            //                   on auction.OrganizationId equals organization.Id
            //                   select new { auction.Description, organization.FullName });

            //var x = auctionInfo.ToList();

            //var auctionInfo2 = dbContext.Auctions
            //    .Select(p => new { p.Description, p.Organization.FullName })
            //    .ToList();


            //var bids = dbContext.Bids
            //    .Where(p => p.AuctionId == auction.Id)
            //    .ToList();

            //var bidSum = bids.Sum(p => p.Price);

            //Mapper.Initialize(p =>
            // {
            //     p.AddProfile<UserProfile>();
            //     p.CreateMap<RegistrationNewUserVm, User>();
            //     p.ValidateInlineMaps = false;
            // });

            restartAuction();


            //UserManagementService service = new UserManagementService(); 
            //var model = service.UserInfo(2);
            //Console.WriteLine(model.ToString());
            //model = service.UserInfo(3);
            //Console.WriteLine(model.ToString());

            //Console.ReadLine();
        }
        public static void CreateUser(int organizationId, int positionId)
        {
            RegistrationNewUserVm reg = new RegistrationNewUserVm()
            {
                Email = "test@mail.ru",
                Password = "1234",
                FirstName = "fname",
                Address = "testAdress",
                LastName = "lname",
                PositionId = positionId,
                OrganizationId = organizationId
            };

            UserManagementService userService = new UserManagementService();
            userService.RegistrationUser(reg);
        }
        public static void CreateOrganization()
        {
            OrganizationManagementService organizationService = new OrganizationManagementService();

            OpenOrganizationRequestVm openOrganization = new OpenOrganizationRequestVm()
            {
                FullName = "TestOrganization",
                IdentificationNumber = "1111-2222-3333",
                OrganizationType = "too"
            };
            organizationService.OpenOrganization(openOrganization);
        }
        public static void OpenAuction(int organizationId)
        {

            OpenAuctionRequestVm openAuction = new OpenAuctionRequestVm()
            {
                Category = "test",
                Description = "TestDiscription",
                FinishDateExpected = DateTime.Now.AddDays(5),
                PriceAtMinimum = 300000,
                PriceAtStart = 500000,
                PriceChangeStep = 50000,
                ShippingAddress = "TestShippingAdress",
                ShippingConditions = "TestShippingConditions",
                StartDate = DateTime.Now            
            };

            AuctionManagementService auctionService = new AuctionManagementService();
            auctionService.OpenAuction(openAuction, organizationId);        
        }

        public static void restartAuction()
        {
            AuctionManagementService auctionService = new AuctionManagementService();
            auctionService.RestartAuction(3, DateTime.Now.AddDays(8));
        }
    }
}
