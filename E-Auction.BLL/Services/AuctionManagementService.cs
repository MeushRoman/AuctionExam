using AutoMapper;
using E_Auction.Core.DataModels;
using E_Auction.Core.Exceptions;
using E_Auction.Core.ViewModels;
using E_Auction.Infrastructure;
using E_Auction.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.BLL.Services
{
    public class AuctionManagementService
    {
        private readonly AplicationDbContext _aplicationDbContext;

        private readonly IAuctionRepository auctionRepository;

        //открыть аукцион
        public void OpenAuction(OpenAuctionRequestVm model, int organizationId)
        {
            if (model == null)
                throw new ArgumentNullException($"{typeof(OpenAuctionRequestVm).Name} is null");

            int maximumAllowedActiveAuctions = 3;

            var auctionsCheck = _aplicationDbContext
                .Organizations
                .Find(organizationId)
                .Auctions
                .Where(p => p.AuctionStatus == AuctionStatus.Active)
                .Count() < maximumAllowedActiveAuctions;

            var categoryCheck = _aplicationDbContext.AuctionCategories
                .SingleOrDefault(p => p.Name == model.AuctionCategory);

            if (categoryCheck == null)
                throw new Exception("Ошибка валидации модели!");

            if (!auctionsCheck)
                throw new OpenAuctionProcessException(model, "Превышено максимальное количество активных аукционов!");

            var auctionModel = Mapper.Map<Auction>(model);
            auctionModel.AuctionStatus = AuctionStatus.Active;
            auctionModel.Category = categoryCheck;
            auctionModel.OrganizationId = organizationId;

            _aplicationDbContext.Auctions.Add(auctionModel);
            _aplicationDbContext.SaveChanges();
        }

        //Сделать Ставку На Аукцион
        public void MakeBidToAuction(MakeBidVm model)
        {
            var bidExists = _aplicationDbContext.Bids
                .Any(p => p.Price == model.Price &&
                p.AuctionId == model.AuctionId &&
                p.Description == model.Description &&
                p.OrganizationId == model.OrganizationId);

            if (bidExists)
                throw new Exception("Invalid bid");

            var inValidPriceRange = _aplicationDbContext
                .Auctions.Where(p => p.Id == model.AuctionId &&
                p.PriceAtMinimum < model.Price &&
                p.PriceAtStart > model.Price);

            var inStepRange = inValidPriceRange
                .Any(p => (p.PriceAtStart - model.Price) % p.PriceChangeStep == 0);

            if (!inStepRange)
                throw new Exception("Invalid bid according price step");

            Bid bid = new Bid()
            {
                Price = model.Price,
                Description = model.Description,
                AuctionId = model.AuctionId,
                OrganizationId = model.OrganizationId,
                CreatedDate = DateTime.Now
            };
            _aplicationDbContext.Bids.Add(bid);
            _aplicationDbContext.SaveChanges();

        }

        //отозвать ставку на аукцион
        public void RevokeBidFromAuction(int BidId)
        {
            var bidExists = _aplicationDbContext.Bids
                .Find(BidId);
            if(bidExists==null)
                throw new Exception("Bid не найден!");
            if ((bidExists.Auction.FinishDateExpected - DateTime.Now).Days < 1)
                throw new Exception("Ставку нельзя удалить! До завершение аукциона осталось менше 24 часов.");
            else
            {
                bidExists.BidStatus = BidStatus.Revoked;
                _aplicationDbContext.SaveChanges();
            }
        }

        public IEnumerable<AuctionInfoVm> GetAuctionInfo()
        {
            var auctions = _aplicationDbContext.Auctions
                .Include("Bids")
                .Include("Organizations")
                .Select(p => new AuctionInfoVm()
                {
                    AuctionName = p.Description,
                    BidsCount = p.Bids.Count,
                    BidsTotalAmount = 0,
                    CreatedByOrganization = p.Organization.FullName
                });

            return auctions.ToList();
        }

        //получить подробную информацию об аукционе
        public FullAuctionInfoVm GetAuctionDetailedInfo(int auctionId)
        {

            var auction = _aplicationDbContext.Auctions.SingleOrDefault(p => p.Id == auctionId); 

            if (auction == null)
                throw new Exception("Invalid auction ID");

            FullAuctionInfoVm model = new FullAuctionInfoVm()
            {
                AuctionId = auction.Id,
                Status = auction.AuctionStatus.ToString(),
                AuctionType = auction.GetType().ToString(),
                OrganizationName = auction.Organization.FullName,
                ShippingAddress = auction.ShippingAddress,
                ShippingConditions = auction.ShippingConditions,
                StartPrice = auction.PriceAtStart,
                PriceStep = auction.PriceChangeStep,
                MinPrice = auction.PriceAtMinimum,
                StartDate = auction.StartDate,
                FinishDate = auction.FinishDateExpected,
                FinishDateAtActual = auction.FinishDateActual

            };
            return model;
        }

        //перезапуск аукциона
        public void RestartAuction(int auctionId)
        {
            
        }

        //Выбрать победителя аукциона
        public void ElectWinnerInAuction(int id)
        {

        }

        public AuctionManagementService()
        {
            _aplicationDbContext = new AplicationDbContext();
            auctionRepository = new AuctionRepository();
        }
    }
}
