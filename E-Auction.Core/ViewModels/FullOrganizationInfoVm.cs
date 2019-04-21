using E_Auction.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.ViewModels
{
    public class FullOrganizationInfoVm
    {
        public string Type { get; set; }
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<User> Users { get; set; }
        public List<Auction> Auctions { get; set; }
        public List<Bid> Bids { get; set; }

        public override string ToString()
        {
            return  $"{Type}\n{FullName}\n{IdentificationNumber}\n{RegistrationDate}\n";
        }
    }
}
