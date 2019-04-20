using AutoMapper;
using E_Auction.Core.DataModels;
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
            if (model == null)
                throw new ArgumentNullException($"{typeof(RegistrationNewUserVm).Name} is null");

            var checkUser = _aplicationDbContext.Users
                                    .SingleOrDefault(p => p.Email == model.Email);

            if (checkUser != null)
                throw new Exception("Model validation error!");

            var checkUserPosition = _aplicationDbContext.UserPositions
                                    .SingleOrDefault(p => p.Id == model.PositionId);

            var checOrganization = _aplicationDbContext.Organizations
                                    .SingleOrDefault(p => p.Id == model.OrganizationId);

            User user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Address = model.Address,
                OrganizationId = model.OrganizationId,
                PositionId = model.PositionId
            };
            

            _aplicationDbContext.Users.Add(user);
            _aplicationDbContext.SaveChanges(); 
        }

        //изменить информацию по сотруднику


        //получить информацию по сотруднику

        public UserInfoVm UserInfo(int userId)
        {
            var user = _aplicationDbContext.Users.SingleOrDefault(p => p.Id == userId);

            if (user == null)
                throw new Exception("Invalid user ID");

            UserInfoVm model = new UserInfoVm()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Adress = user.Address,               
                PositionId = user.PositionId
            };

            return model;
        }

        //получить информацию по сотрудникам из организации





        public UserManagementService()
        {
            _aplicationDbContext = new AplicationDbContext();          
        }        
    }
}
