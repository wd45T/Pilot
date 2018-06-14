using Pilot.Common.Model;
using Pilot.DataCore;
using Pilot.Repository.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Repository.Interfaces
{
    public interface IUserRepository : IReadRepository<User, UserResponse>
    {
    }
}
