using System;
using ServiceAPI.Log;
using System.Net;
using System.Net.Sockets;

namespace MiddlewareAPI.Network
{
    public class Server : INetworkUnit
    {
        public bool IsWork => socket != null && socket.Connected;

        private Socket socket;
        private ILogger logger;
        private int maximalConnectionCount = 16;


        public Server(ILogger logger)
        {
            this.logger = logger;
        }

        public void StartServer(int port, int maximumConnection)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            maximalConnectionCount = maximumConnection;

            if (socket == null)
            {
                socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            }

            try
            {
                socket.Bind(endPoint);

                socket.Listen(maximalConnectionCount);

                logger.LogMessage($"Server was started successful");
            }
            catch (Exception e)
            {
                logger.ErrorMessage($"Server initialization failed:{e.Message}");
            }


            //byte[] recieveBuffer = new byte[2048];

            while (true)
            {
                Socket handler = socket.Accept();

                logger.LogMessage($"Incoming user {handler.RemoteEndPoint}");

                //int recievedBytes = 0;
                //int allRecieved = 0;

                //using (var stream = new StreamWriter(@"temp.FBX"))
                //{
                //    do
                //    {
                //        recievedBytes = handler.Receive(recieveBuffer);

                //        stream.BaseStream.Write(recieveBuffer, 0, recievedBytes);

                //        allRecieved += recievedBytes;
                //    }
                //    while (handler.Available > 0);
                //}

                //logger.LogMessage($"Recieved {allRecieved} bytes");
                //logger.LogMessage($"Recieved {allRecieved / 1024 / 1024} Mb");
            }

        }

        public string Recieve()
        {
            byte[] recieveBuffer = new byte[2048];

            SocketAsyncEventArgs eventArgs = new SocketAsyncEventArgs();

            eventArgs.SetBuffer(recieveBuffer, 0, recieveBuffer.Length);
            socket.ReceiveAsync(eventArgs);

            return System.Text.Encoding.Default.GetString(recieveBuffer, 0, eventArgs.Count);
        }

        public void Send(string value)
        {
            throw new NotImplementedException();
        }
    }
}
