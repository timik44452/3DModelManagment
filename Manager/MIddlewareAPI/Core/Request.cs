using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareAPI.Core
{
    public struct Request
    {
        public string Value;

        public Request(string Value)
        {
            this.Value = Value;
        }

        public static implicit operator Request(string value)
        {
            return new Request(value);
        }
    }
}
