using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Core.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }   
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public UserPosition Position { get; set; }
        public User()
        {
                
        }

    }
    public class UserPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public UserPosition()
        {
            Users = new List<User>();
        }
    }
}
