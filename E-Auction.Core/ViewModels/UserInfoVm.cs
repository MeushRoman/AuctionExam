using E_Auction.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.ViewModels
{
    public class UserInfoVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }

        public override string ToString()
        {
            return $"{FirstName}\n{LastName}\n{PositionId.ToString()}\n{Email}\n{Adress}";
        }
    }
    
}
