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

        //регистрация
        public int RegistrationUser(RegistrationNewUserVm model)
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
            return user.Id;
        }

        //создать новую позицию
        public int CreateUserPosition(string newUserPosition)
        {
            var checkPosition = _aplicationDbContext.UserPositions.FirstOrDefault(p => p.Name == newUserPosition);

            if (checkPosition != null)
                throw new Exception("Incorrect userPosition");

            UserPosition position = new UserPosition()
            {
                Name = newUserPosition
            };

            _aplicationDbContext.UserPositions.Add(position);
            _aplicationDbContext.SaveChanges();
            return position.Id;
        }
        //изменить информацию по сотруднику

        public void ChangeUserInfo(ChangeUserInfoVm model)
        {
            
        }

        public void ChangeUserEmail(UserAuthorizationVm model, string newEmail)
        {

        }

        //смена пароля
        public void ChangeUserPassword(UserAuthorizationVm model, string newPassword)
        {
            User user = Autorization(model);
            user.Password = newPassword;

            _aplicationDbContext.SaveChanges();
        }

        //авторизация
        public User Autorization(UserAuthorizationVm model)
        {
            if (model == null)
                throw new Exception("Invalid model");

            var checkUser = _aplicationDbContext.Users.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);

            if (checkUser == null)
                throw new Exception("Invalid Email or Password!");

            return checkUser;
        }

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
       

        public UserManagementService()
        {
            _aplicationDbContext = new AplicationDbContext();
        }
    }
}
