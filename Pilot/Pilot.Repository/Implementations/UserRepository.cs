using Pilot.Common.Model;
using Pilot.DataCore;
using Pilot.Repository.BaseClasses;
using Pilot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Repository.Implementations
{
    public class UserRepository : BaseRepository<User, UserResponse> , IUserRepository
    {
        public UserRepository(DataManager dataManager) : base(dataManager) { }
    }
}
