using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.DataModels
{
    public class OrganizationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }

        public OrganizationType()
        {
            Organizations = new List<Organization>();
        }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkToSite { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int OrganizationTypeId { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<Bid> Bids { get;set; }
        public ICollection<AuctionWinner> AuctionWinner { get; set; }

        public Organization()
        {
            Auctions = new List<Auction>();
            Bids = new List<Bid>();
            Users = new List<User>();
        }
    }
}
