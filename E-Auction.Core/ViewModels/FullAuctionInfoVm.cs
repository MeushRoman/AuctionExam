using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.ViewModels
{
    public class FullAuctionInfoVm
    {
        public int AuctionId { get; set; }
        public string Status { get; set; }
        public string AuctionType { get; set; }
        public string OrganizationName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingConditions { get; set; }
        public decimal StartPrice { get; set; }
        public decimal PriceStep { get; set; }
        public decimal MinPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime? FinishDateAtActual { get; set; }
      //  public List<AuctionFile> AuctionFiles { get; set; }
    }
}
