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

            CreateMap<Enterprise, EnterpriseResponse>();

        }
    }
}
