using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.DataCore.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        DateTime? Deleted { get; set; }
    }
}
