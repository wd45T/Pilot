using AutoMapper;
using Pilot.Common.Model;
using Pilot.DataCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Repository.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
