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
           // CreateUser(1, createUserPosition())   ;
            //CreateOrganization();
            OrganizationInfo();
        }

        public static int createUserPosition()
        {
            UserManagementService service = new UserManagementService();
            //service.CreateUserPosition("Director");
            return service.CreateUserPosition("Director");
        }

        public static void CreateUser(int organizationId, int positionId)
        {
            RegistrationNewUserVm reg = new RegistrationNewUserVm()
            {
                Email = "test2@mail.ru",
                Password = "1234",
                FirstName = "Director1",
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
                OrganizationType = "TOO"
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
        public static void CreateCategoryAuction()
        {
            CreateAuctionCategoryVm newCategory = new CreateAuctionCategoryVm()
            {
                Name = "NameCategory",
                Discription = "TestDiscription"               
            };

            AuctionManagementService service = new AuctionManagementService();
            service.CreateAuctionCategory(newCategory);

        }
        public static void AddTypeOrganization()
        {
            CreateOrganizationTypeVm model = new CreateOrganizationTypeVm()
            {
                Name = "ИП"
            };

            OrganizationManagementService service = new OrganizationManagementService();
            service.AddTypeOrganization(model);      
        }

        public static void OrganizationInfo()
        {
            OrganizationManagementService service = new OrganizationManagementService();
            Console.WriteLine(service.FullOrganizationInfo(1)); 
            
        }

        public static void restartAuction()
        {
            AuctionManagementService auctionService = new AuctionManagementService();
            auctionService.RestartAuction(3, DateTime.Now.AddDays(8));
        }
    }
}
