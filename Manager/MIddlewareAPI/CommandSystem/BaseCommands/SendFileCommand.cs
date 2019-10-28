using System.IO;
using System.Net.Sockets;

namespace MiddlewareAPI.CommandSystem
{
    public class SendFileCommand : ICommand
    {
        public string Name => "sef";

        public DataContainer Data { get; set; }



        public DataContainer Work(DataContainer data)
        {
            DataContainer result = new DataContainer();

            return result;
        }

        public DataContainer Work()
        {
            throw new System.NotImplementedException();
        }
    }
}   
