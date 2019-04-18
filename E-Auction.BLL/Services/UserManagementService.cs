using E_Auction.Core.ViewModels;
using E_Auction.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.BLL.Services
{
   
    public class UserManagementService
    {
        private readonly AplicationDbContext _aplicationDbContext;

        //создание пользователя
        public void RegistrationUser(RegistrationNewUserVm model)
        {
            
            var user =  _aplicationDbContext.Users
                                    .SingleOrDefault(p => p.Email == model.Email);

            if(user != null)
                throw new Exception("Model validation error!");

            

            

        }

        //изменить информацию по сотруднику

        //получить информацию по сотруднику

        public UserInfoVm UserInfo(int userId)
        {
            var auction = _aplicationDbContext.Users.SingleOrDefault(p => p.Id == userId);

            if (auction == null)
                throw new Exception("Invalid user ID");
            return null;
        }

        //получить информацию по сотрудникам из организации


    }
}
