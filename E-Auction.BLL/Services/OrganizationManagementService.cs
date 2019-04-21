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
    public class OrganizationManagementService
    {
        private readonly AplicationDbContext _aplicationDbContext;

        //добавить орагинизвцию
        public int OpenOrganization(OpenOrganizationRequestVm model)
        {
            if (model == null)
                throw new ArgumentNullException($"{typeof(OpenOrganizationRequestVm).Name} is null");

            var checkOrganization = _aplicationDbContext.Organizations
                                    .SingleOrDefault(p => p.IdentificationNumber == model.IdentificationNumber || p.FullName == model.FullName);

            var checkOrganizationType = _aplicationDbContext.OrganizationTypes
                                    .SingleOrDefault(p => p.Name == model.OrganizationType);

            if (checkOrganization != null || checkOrganizationType == null)
                throw new Exception("Model validation error!");

            Organization organization = new Organization()
            {
                FullName = model.FullName,
                IdentificationNumber = model.IdentificationNumber,
                OrganizationType = checkOrganizationType,
                RegistrationDate = DateTime.Now,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Adress = model.Adress,
                LinkToSite = model.LinkToSite
            };

            _aplicationDbContext.Organizations.Add(organization);
            _aplicationDbContext.SaveChanges();
            return organization.Id;
        }

        //добавление типа организации
        public int AddTypeOrganization(CreateOrganizationTypeVm model)
        {
            var checkType = _aplicationDbContext.OrganizationTypes.FirstOrDefault(p => p.Name == model.Name);
            if (checkType != null)
                throw new Exception("incorrect model!");

            OrganizationType type = new OrganizationType()
            {
                Name = model.Name
            };

            _aplicationDbContext.OrganizationTypes.Add(type);
            _aplicationDbContext.SaveChanges();
            return type.Id;
        }

        //изменение данных организаии
        public void ChangeOrganization(ChangeOrganizationVm model, int organizationId) 
        {
            var organization = _aplicationDbContext.Organizations.FirstOrDefault(p => p.Id == organizationId);

            if (organization == null)
                throw new Exception("Incorrect organizationId");
           
            organization.FullName = model.FullName;
            organization.IdentificationNumber = model.IdentificationNumber;
            organization.RegistrationDate = model.RegistrationDate;
            organization.OrganizationTypeId = model.OrganizationTypeId;
            organization.Email = model.Email;
            organization.PhoneNumber = model.PhoneNumber;
            organization.Adress = model.Adress;
            organization.LinkToSite = model.LinkToSite;

            _aplicationDbContext.SaveChanges();
        }

        //получить информацию по организации
        public FullOrganizationInfoVm FullOrganizationInfo(int organizationId)
        {
            var checkOrganization = _aplicationDbContext
                .Organizations            
                .FirstOrDefault(p => p.Id == organizationId);

            if (checkOrganization == null)
                throw new Exception("Invalid organizationId");

            string organizationType = _aplicationDbContext.OrganizationTypes.Find(checkOrganization.OrganizationTypeId).Name;

            return new FullOrganizationInfoVm()
            {
                Type = checkOrganization.OrganizationType.Name,
                FullName = checkOrganization.FullName,
                IdentificationNumber = checkOrganization.IdentificationNumber,
                RegistrationDate = checkOrganization.RegistrationDate,
                Auctions = checkOrganization.Auctions.ToList(),
                Bids = checkOrganization.Bids.ToList(),
                Users = checkOrganization.Users.ToList()
            };
        }

        public OrganizationManagementService()
        {
            _aplicationDbContext = new AplicationDbContext();
        }
    }
}
