using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.ViewModels
{
    public class AuctionInfoVm
    {
        public string AuctionName { get; set; }
        public string CreatedByOrganization { get; set; }
        public int BidsCount { get; set; }
        public decimal BidsTotalAmount { get; set; }

        public override string ToString()
        {
            return $"{AuctionName}\n{CreatedByOrganization}\n{BidsCount.ToString()}\n{BidsTotalAmount.ToString()}";
        }
    }
}
