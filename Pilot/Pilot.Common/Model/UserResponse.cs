using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model
{
    public class UserResponse
    {                                        
       public Guid Id { get; set; }
       public string Name { get; set; } 
       public DateTime Created { get; set; } 
       public DateTime Modified { get; set; }
    }
}
