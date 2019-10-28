using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareAPI.Network
{
    public interface INetworkUnit
    {
        bool IsWork { get; }
        void Send(string value);
        string Recieve();
    }
}
