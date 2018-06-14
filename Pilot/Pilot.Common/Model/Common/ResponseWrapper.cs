using System;
using System.Collections.Generic;
using System.Text;

namespace Pilot.Common.Model.Common
{
    public class ResponseWrapper<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
        public int Status { get; set; }
        public MetaResponse Meta { get; set; }
    }
}
