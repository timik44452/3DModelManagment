using System;
using System.Net;
using System.Net.Sockets;
using ServiceAPI;

namespace MiddlewareAPI
{
    public class FileServer
    {
        private Socket socket;

        private int port = 67;
        private int maximalConnectionCount = 16;

        private ILogger logger;

        private bool isWork = true;

        private byte[] recieveBuffer;

        public FileServer(int port, ILogger logger)
        {
            this.port = port;
            this.logger = logger;

            recieveBuffer = new byte[2048];
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

            try
            {
                socket.Bind(endPoint);

                socket.Listen(maximalConnectionCount);

                logger.LogMessage($"Server was started successful");

                while (isWork)
                {
                    Socket handler = socket.Accept();

                    logger.LogMessage($"Incoming user {handler.RemoteEndPoint}");

                    int recievedBytes = 0;
                    int allRecieved = 0;

                    using (var stream = new System.IO.StreamWriter(@"temp.FBX"))
                    {
                        do
                        {
                            recievedBytes = handler.Receive(recieveBuffer);

                            stream.BaseStream.Write(recieveBuffer, 0, recievedBytes);

                            allRecieved += recievedBytes;
                        }
                        while (handler.Available > 0);
                    }

                    //System.IO.File.WriteAllBytes(@"temp.FBX", file);

                    logger.LogMessage($"Recieved {allRecieved} bytes");
                    logger.LogMessage($"Recieved {allRecieved / 1024 / 1024} Mb");
                }

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
        }
    }
}