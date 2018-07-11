using AutoMapper;
using Pilot.Common.Model;
using Pilot.DataCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pilot.Repository.Mappings
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserResponse>();


            CreateMap<Bank, BankResponse>();

            CreateMap<PaymentAccount, PaymentAccountResponse>();

            CreateMap<EnterpriseBank, EnterpriseBankResponse>();

            CreateMap<Enterprise, EnterpriseResponse>()
                .ForMember(x => x.ManagerId, o => o.MapFrom(s => s.Manager))
                .ForMember(x=>x.ManagerName, 
                    o=>o.MapFrom(s=> $"{s.ManagerRef.FirstName} {s.ManagerRef.Patronymic} {s.ManagerRef.FirstName}"));

        }
    }
}
