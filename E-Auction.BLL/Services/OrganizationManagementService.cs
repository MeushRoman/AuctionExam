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

        public void OpenOrganization(OpenOrganizationRequestVm model)
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
                RegistrationDate = DateTime.Now
            };

            _aplicationDbContext.Organizations.Add(organization);
            _aplicationDbContext.SaveChanges();
        }


        public OrganizationManagementService()
        {
            _aplicationDbContext = new AplicationDbContext();
        }
    }
}
