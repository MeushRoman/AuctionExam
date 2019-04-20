using AutoMapper;
using E_Auction.Core.DataModels;
using E_Auction.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.BLL.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationNewUserVm, User>()
                .ForMember(p => p.Email,
                  opt => opt.MapFrom(p => p.Email))
                .ForMember(p => p.FirstName,
                 opt => opt.MapFrom(p => p.FirstName))
                 .ForMember(p => p.LastName,
                 opt => opt.MapFrom(p => p.LastName))
                 .ForMember(p => p.Password,
                 opt => opt.MapFrom(p => p.Password))
                 .ForMember(p => p.OrganizationId,
                 opt => opt.MapFrom(p => p.OrganizationId))
                 .ForMember(p => p.PositionId,
                 opt => opt.MapFrom(p => p.PositionId));
             

        }

      
    }
}
