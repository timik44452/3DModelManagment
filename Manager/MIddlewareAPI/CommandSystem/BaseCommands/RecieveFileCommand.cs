using System.IO;
using System.Net.Sockets;

namespace MiddlewareAPI.CommandSystem
{
    public class RecieveFileCommand : ICommand
    {
        public string Name => "rcf";

        public DataContainer Data { get; set; }

        public RecieveFileCommand(Socket socket)
        {
            Data = new DataContainer();
            Data.SetObject("Socket", socket);
        }

        public DataContainer Work()
        {
            DataContainer result = new DataContainer();

            Socket socket = Data.GetObject<Socket>("Socket");
            byte[] recieveBuffer = new byte[2048];

            foreach (string path in Data.GetObject<string[]>("Args"))
            {
                int allRecieved = 0;
                int recievedBytes = 0;

                using (var stream = new StreamWriter(path))
                {
                    do
                    {
                        recievedBytes = socket.Receive(recieveBuffer);

                        stream.BaseStream.Write(recieveBuffer, 0, recievedBytes);

                        allRecieved += recievedBytes;
                    }
                    while (socket.Available > 0);
                }

                result.SetObject(path, allRecieved);
            }

            return result;
        }
    }
}
